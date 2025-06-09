using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphe    
{
    public class Noeud
    {
        public Arret Arret { get; set; }
        public List<Arete> ArcsSortants { get; private set; }

        public Noeud(Arret arret)
        {
            Arret = arret;
            ArcsSortants = new List<Arete>();
        }

        public void AjouterArc(Noeud destination, int poids)
        {
            var arc = new Arete(this, destination, poids);
            ArcsSortants.Add(arc);
        }

        public override string ToString()
        {
            return $"Noeud({Arret.Nom}, lat={Arret.Latitude}, long={Arret.Longitude})";
        }
    }
}
