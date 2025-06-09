    using System;
    using System.Collections.Generic;

namespace Graphe
{
    public class GrapheBuilder
    {
        public Dictionary<int, Noeud> Noeuds { get; private set; }
        public Dictionary<int, Dictionary<int, int>> MatriceAdjacence { get; private set; }

        // Données simulées (à remplir avant appel à ChargerGrapheEtMatrice)
        public List<Arret> Arrets { get; set; } = new();
        public List<(int srcId, int destId, int poids)> Aretes { get; set; } = new();
        public Dictionary<int, List<Arret>> ArretsParLigne { get; set; } = new();

        public GrapheBuilder()
        {
            Noeuds = new Dictionary<int, Noeud>();
            MatriceAdjacence = new Dictionary<int, Dictionary<int, int>>();
        }

        public void ChargerGrapheEtMatrice()
        {
            bool grapheVide = true;

            try
            {
                if (Arrets.Count > 0 && Aretes.Count > 0)
                {
                    foreach (var arret in Arrets)
                    {
                        var noeud = new Noeud(arret);
                        Noeuds[arret.Id] = noeud;
                        MatriceAdjacence[arret.Id] = new Dictionary<int, int>();
                        grapheVide = false;
                    }

                    foreach (var (srcId, destId, poids) in Aretes)
                    {
                        if (Noeuds.ContainsKey(srcId) && Noeuds.ContainsKey(destId))
                        {
                            Noeuds[srcId].AjouterArc(Noeuds[destId], poids);
                            MatriceAdjacence[srcId][destId] = poids;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors du chargement du graphe : " + ex.Message);
            }

            if (grapheVide)
            {
                Console.WriteLine("Aucune donnée fournie. Génération d'un pseudo-graphe...");

                for (int i = 1; i <= 4; i++)
                {
                    var arret = new Arret(i, $"Arret {i}", 48.0 + i * 0.001, 2.0 + i * 0.001);
                    var noeud = new Noeud(arret);
                    Noeuds[i] = noeud;
                    MatriceAdjacence[i] = new Dictionary<int, int>();
                }

                AjouterAreteFictive(1, 2, 5);
                AjouterAreteFictive(2, 3, 4);
                AjouterAreteFictive(3, 4, 6);
                AjouterAreteFictive(1, 4, 12);
            }
        }

        private void AjouterAreteFictive(int src, int dest, int poids)
        {
            if (Noeuds.ContainsKey(src) && Noeuds.ContainsKey(dest))
            {
                Noeuds[src].AjouterArc(Noeuds[dest], poids);
                MatriceAdjacence[src][dest] = poids;
            }
        }

        public List<Arete> ConstruireTrajetLigne(int idLigne)
        {
            if (!ArretsParLigne.ContainsKey(idLigne))
                return new List<Arete>();

            var arretsDeLigne = ArretsParLigne[idLigne];
            List<Arete> trajet = new();

            for (int i = 0; i < arretsDeLigne.Count - 1; i++)
            {
                var src = Noeuds.Values.First(n => n.Arret.Id == arretsDeLigne[i].Id);
                var dst = Noeuds.Values.First(n => n.Arret.Id == arretsDeLigne[i + 1].Id);
                var arete = src.ArcsSortants.FirstOrDefault(a => a.Destination == dst);
                if (arete != null)
                    trajet.Add(arete);
            }

            return trajet;
        }
    }
}