using Graphe;

namespace SaeGraphe
{
    public static class Afficheur
    {
        public static void AfficherResultat(List<Itineraire>? itineraires)
        {
            if (itineraires == null || itineraires.Count == 0)
            {
                Console.WriteLine("Aucun itinéraire trouvé.");
                return;
            }

            int i = 1;
            foreach (var itineraire in itineraires)
            {
                Console.WriteLine($"\nItinéraire {i++} :");
                Console.WriteLine($"Temps total : {itineraire.TempsTotal} min");
                Console.WriteLine("Lignes empruntées : " + string.Join(", ", itineraire.Lignes));
                Console.WriteLine("Trajet : " + string.Join(" -> ", itineraire.Chemin.Select(n => n.Arret.Nom)));
            }
        }
    }
}
