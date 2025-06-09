using System;
using System.Collections.Generic;

namespace Graphe
{
    public class Dijkstra
    {
        public Dictionary<Noeud, int> Distances { get; private set; } = new();
        public Dictionary<Noeud, Noeud?> Predecesseurs { get; private set; } = new();

        public void CalculerChemins(Noeud source, List<Noeud> tousLesNoeuds)
        {
            Distances = new Dictionary<Noeud, int>();
            Predecesseurs = new Dictionary<Noeud, Noeud?>();

            foreach (var noeud in tousLesNoeuds)
            {
                Distances[noeud] = int.MaxValue;
                Predecesseurs[noeud] = null;
            }

            Distances[source] = 0;

            var nonVisites = new List<Noeud>(tousLesNoeuds);

            while (nonVisites.Count > 0)
            {
                Noeud? noeudActuel = null;
                int distanceMin = int.MaxValue;

                foreach (var noeud in nonVisites)
                {
                    if (Distances[noeud] < distanceMin)
                    {
                        distanceMin = Distances[noeud];
                        noeudActuel = noeud;
                    }
                }

                if (noeudActuel == null)
                    break;

                nonVisites.Remove(noeudActuel);

                foreach (var arc in noeudActuel.ArcsSortants)
                {
                    var voisin = arc.Destination;
                    int nouvelleDistance = Distances[noeudActuel] + arc.Poids;

                    if (nouvelleDistance < Distances[voisin])
                    {
                        Distances[voisin] = nouvelleDistance;
                        Predecesseurs[voisin] = noeudActuel;
                    }
                }
            }
        }

        public List<Noeud> RecupererChemin(Noeud destination)
        {
            List<Noeud> chemin = new();
            Noeud? courant = destination;

            while (courant != null)
            {
                chemin.Insert(0, courant);
                if (!Predecesseurs.TryGetValue(courant, out var suivant))
                    break;
                courant = suivant;
            }

            return chemin;
        }
    }
}
