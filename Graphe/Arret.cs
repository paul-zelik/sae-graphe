using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphe {
    public class Arret
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }



        public Arret(int id, string nom, double latitude, double longitude)
        {
            Id = id;
            Nom = nom;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
