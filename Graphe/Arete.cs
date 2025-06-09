using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphe    
{
    public class Arete
    {
        public Noeud Source { get; private set; }
        public Noeud Destination { get; private set; }
        public int Poids { get; private set; }

        public Arete(Noeud source, Noeud destination, int poids)
        {
            Source = source;
            Destination = destination;
            Poids = poids;
        }

        public override string ToString()
        {
            return $"Arete({Source.Arret.Nom} -> {Destination.Arret.Nom}, poids={Poids})";
        }
    }
}
