using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphe;

namespace SaeGraphe
{
    public static class Calculateur
    {
        public static List<Itineraire>? CalculerItineraire(GrapheBuilder builder, int idDepart, int idArrivee)
        {
            if (!builder.Noeuds.ContainsKey(idDepart) || !builder.Noeuds.ContainsKey(idArrivee))
                return null;

            var finder = new ItineraireFinder(builder)
            {
                LignesParCoupleArrets = InitialiserLignes()
            };

            return finder.TrouverItineraires(builder.Noeuds[idDepart], builder.Noeuds[idArrivee]);
        }

        private static Dictionary<(string, string), List<string>> InitialiserLignes()
        {
            return new Dictionary<(string, string), List<string>>
            {
                { ("1", "2"), new List<string> { "Ligne A" } },
                { ("2", "3"), new List<string> { "Ligne A" } },
                { ("1", "3"), new List<string> { "Ligne B" } }
            };
        }
    }


}
