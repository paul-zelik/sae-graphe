using System;
using Graphe;

namespace SaeGraphe
{
    public static class Utilisateur
    {
        public static (int, int) DemanderItineraire()
        {
            Console.Write("Entrez l'ID de l'arrêt de départ : ");
            int depart = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Entrez l'ID de l'arrêt d'arrivée : ");
            int arrivee = int.Parse(Console.ReadLine() ?? "0");

            return (depart, arrivee);
        }
    }
}
