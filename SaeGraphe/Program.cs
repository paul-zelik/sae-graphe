using Graphe;
using SaeGraphe;


var builder = new GrapheBuilder();

builder.Arrets.AddRange(new List<Arret>
{
    new Arret(1, "Gare", 0, 0),
    new Arret(2, "Université", 0, 0),
    new Arret(3, "Centre-ville", 0, 0),
});

builder.Aretes.AddRange(new List<(int, int, int)>
{
    (1, 2, 5),
    (2, 3, 4),
    (1, 3, 10)
});

builder.ChargerGrapheEtMatrice();

var (depart, arrivee) = Utilisateur.DemanderItineraire();
var resultats = Calculateur.CalculerItineraire(builder, depart, arrivee);
Afficheur.AfficherResultat(resultats);


