using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace firstProjectCSharp.Pages;

public class CalculationModel : PageModel
{
  public string ResultatCocktail { get; set; } = "";
  public string ResultatDiner { get; set; } = "";
  public string ResultatTotal { get; set; } = "";
  public void OnGet()
  {
    int paxCocktail = 80;
    int paxDiner = 70;
    int verre = 1;
    double bouteille = 6.5 * verre;

    // Cocktail Mousseux Rosé :

    // Partir sur 3 verres d’alcool par personne
    //  (Mousseux : 6.5 verres dans 1 bouteille)

    int cocktailVerres = 3 * paxCocktail;
    double cocktailBtlles = cocktailVerres / bouteille;


    // Rosé 20 % de cocktailBtlles
    double roseBtlles = (double)(20 * cocktailBtlles) / 100;


    int cocktailMousseux = (int)(cocktailBtlles - roseBtlles);
    // prendre un carton au dessus si le remainder est de 3 mini + 1 carton d'alerte
    double cocktailMousseuxCarton = (cocktailBtlles / 6) + 1;
    if (cocktailBtlles % 6 >= 3)
    {
      cocktailMousseuxCarton++;
    }
    double roseCarton = roseBtlles / 6;
    Console.WriteLine("Nombre de carton de Mousseux pour le cocktail : " + Math.Floor(cocktailMousseuxCarton));
    Console.WriteLine("Nombre de carton de Rosé pour le cocktail : " + Math.Floor(roseBtlles / 6));

    ResultatCocktail =
    $"Il faut {Math.Floor(cocktailBtlles)} bouteilles de mousseux dont {Math.Floor(roseBtlles)} de rosé pour le cocktail\n" +
    $"Nombre de cartons de Mousseux pour le cocktail : {Math.Floor(cocktailMousseuxCarton)}\n" +
    $"Nombre de cartons de Rosé pour le cocktail : {Math.Floor(roseCarton)}";
    // Diner Rouge Blanc

    // Partir sur 1 bttle de vin pour 3 personnes 
    // Bulles pour le dessert : compter 1 bouteille pour 6 personnes

    // vins :

    int dinerBtlles = paxDiner / 3;
    int dessertBtlles = paxDiner / 6;
    Console.WriteLine($" vins au repas {dinerBtlles} bouteilles et mousseux pour dessert {dessertBtlles} bouteilles pour {paxDiner} personnes.");

    // prendre un carton au dessus si le remainder est de 3  + 1 carton d'alerte
    double dinerCarton = (dinerBtlles / 6) + 1;
    if (dinerBtlles % 6 >= 3)
    {
      dinerCarton++;
    }

    Console.WriteLine("Nombre de carton pour le repas : " + dinerCarton + " , cartons par couleur :");
    // 100 = 50 % rouge + 20% Blanc sec + 10% blanc fruité
    // Nombre de carton de vins rouges :
    double rougeCarton = (double)(50 * dinerCarton) / 100;
    Console.WriteLine("\tCartons de rouge : " + Math.Ceiling(rougeCarton));
    // Nombre de carton de vins blancs :
    double blancCarton = (double)(30 * dinerCarton) / 100;
    Console.WriteLine("\tCartons de blanc sec : " + Math.Ceiling(blancCarton));
    // Nombre de carton de vins blancs fruités :
    double blancFruiteCarton = (double)(20 * dinerCarton) / 100;
    Console.WriteLine("\tCartons de blanc fruités : " + Math.Ceiling(blancFruiteCarton));



    double dessertCarton = dessertBtlles / 6;
    if (dessertBtlles % 6 >= 3)
    {
      dessertCarton++;
    }
    Console.WriteLine("Cartons de mousseux pour le dessert : " + dessertCarton);
    Console.WriteLine("Total de cartons de mousseux : " + Math.Round(dessertCarton + cocktailMousseuxCarton));

  }
}
