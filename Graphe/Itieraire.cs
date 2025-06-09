using Graphe;

namespace Graphe
{
    public class Itineraire
    {
        private int temps;

        public int TempsTotal { get; set; }
        public List<string> Lignes { get; set; }
        public List<Noeud> Chemin { get; set; }
        public DateTime HeureDepart { get; set; }

        public Itineraire(int temps, List<string> lignes, List<Noeud> chemin, DateTime heureDepart)
        {
            TempsTotal = temps;
            Lignes = lignes;
            Chemin = chemin;
            HeureDepart = heureDepart;
        }

        public Itineraire(int temps, List<string> lignes, List<Noeud> chemin)
        {
            this.temps = temps;
            Lignes = lignes;
            Chemin = chemin;
        }

        public DateTime GetHeureDepart() => HeureDepart;

        public DateTime GetHeureArrivee() => HeureDepart.AddMinutes(TempsTotal);

        public string GetDureeHumaine()
        {
            int heures = TempsTotal / 60;
            int minutes = TempsTotal % 60;
            return heures > 0 ? $"{heures}h {minutes}min" : $"{minutes}min";
        }

        public override string ToString()
        {
            return $"Temps: {TempsTotal} min, Lignes: {string.Join(" -> ", Lignes)}, Étapes: {Chemin.Count}";
        }
    }
}