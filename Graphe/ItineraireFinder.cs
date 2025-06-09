using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphe
{
    public class ItineraireFinder
    {
        private readonly GrapheBuilder grapheBuilder;

        // Dictionnaire (arret1Id, arret2Id) → liste de lignes
        public Dictionary<(string, string), List<string>> LignesParCoupleArrets { get; set; }

        public ItineraireFinder(GrapheBuilder builder)
        {
            grapheBuilder = builder;
            LignesParCoupleArrets = new Dictionary<(string, string), List<string>>();
        }

        public List<Itineraire> TrouverItineraires(Noeud depart, Noeud arrivee)
        {
            var resultats = new List<Itineraire>();
            var dejaVisites = new HashSet<string>();

            for (int i = 0; i < 3; i++)
            {
                var dijkstra = new Dijkstra();
                dijkstra.CalculerChemins(depart, grapheBuilder.Noeuds.Values.ToList());

                var chemin = dijkstra.RecupererChemin(arrivee);
                string identifiantChemin = string.Join("-", chemin.Select(n => n.Arret.Id));

                if (chemin.Count == 0 || dejaVisites.Contains(identifiantChemin))
                    break;

                dejaVisites.Add(identifiantChemin);

                int temps = dijkstra.Distances[arrivee];
                var lignes = ExtraireLignesDepuisChemin(chemin);

                resultats.Add(new Itineraire(temps, lignes, chemin));

                SupprimerUneAreteDansChemin(chemin);
            }

            return resultats;
        }

        private List<string> ExtraireLignesDepuisChemin(List<Noeud> chemin)
        {
            var lignes = new List<string>();

            for (int i = 0; i < chemin.Count - 1; i++)
            {
                var arret1 = chemin[i].Arret;
                var arret2 = chemin[i + 1].Arret;

                (string, string) cle1 = (arret1.Id.ToString(), arret2.Id.ToString());
                (string, string) cle2 = (arret2.Id.ToString(), arret1.Id.ToString());

                if (LignesParCoupleArrets.TryGetValue(cle1, out var lignesAB) ||
                    LignesParCoupleArrets.TryGetValue(cle2, out lignesAB))
                {
                    foreach (var ligne in lignesAB)
                    {
                        if (!lignes.Contains(ligne))
                            lignes.Add(ligne);
                    }
                }
            }

            return lignes;
        }

        private void SupprimerUneAreteDansChemin(List<Noeud> chemin)
        {
            if (chemin.Count < 2) return;

            var random = new Random();
            int index = random.Next(0, chemin.Count - 1);

            var source = chemin[index];
            var destination = chemin[index + 1];

            source.ArcsSortants.RemoveAll(a => a.Destination == destination);
        }
    }
}
