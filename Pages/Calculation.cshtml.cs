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
    double bouteille = 6.5;

    // Cocktail Mousseux Rosé :
    // Partir sur 2 verres d’alcool par personne

    int cocktailVerres = 2 * paxCocktail;
    double cocktailBtlles = cocktailVerres / bouteille;

    // Rosé 20 % de cocktailBtlles
    double roseBtlles = (double)(20 * cocktailBtlles) / 100;
    int cocktailMousseux = (int)(cocktailBtlles - roseBtlles);
    double cocktailMousseuxCarton = cocktailMousseux / 6;
    // prendre un carton au dessus si le remainder est de 1 
    if (cocktailMousseux % 6 >= 1)
    {
      cocktailMousseuxCarton++;
    }
    double roseCarton = roseBtlles / 6;

    if (roseBtlles < 6)
    {
      roseCarton = 1;
    }
    ResultatCocktail =
    $"Minimum :  {cocktailMousseux} bouteilles de mousseux et {Math.Floor(roseBtlles)} de rosé pour le cocktail.\n\n" +
    $"Bouteilles de vin prévues {cocktailMousseuxCarton * 6} Mousseux {roseCarton * 6}\n" +
    $"Nombre de cartons de Mousseux pour le cocktail : {Math.Ceiling(cocktailMousseuxCarton)}\n" +
    $"Nombre de cartons de Rosé pour le cocktail : {Math.Ceiling(roseCarton)}";

    // Diner Rouge Blanc
    // Partir sur 1 bttle de vin pour 3 personnes. 
    // Bulles pour le dessert : compter 1 bouteille pour 6 personnes

    // vins :

    int dinerBtlles = paxDiner / 3;
    int dessertBtlles = paxDiner / 6;
    // prendre un carton au dessus si le remainder est de 1  
    double dinerCarton = (dinerBtlles / 6);
    if (dinerBtlles % 6 >= 1)
    {
      dinerCarton++;
    }

    // 100 = 50 % rouge + 30% Blanc sec + 20% blanc fruité
    // Nombre de carton de vins rouges :
    double rougeCarton = (double)(60 * dinerCarton) / 100;
    // Nombre de carton de vins blancs :
    double blancCarton = (double)(20 * dinerCarton) / 100;
    // Nombre de carton de vins blancs fruités :
    double blancFruiteCarton = (double)(20 * dinerCarton) / 100;

    double dessertCarton = dessertBtlles / 6;

    if (blancCarton <= 1)
    {
      blancCarton++;
    }
    double mousseuxCarton = cocktailMousseuxCarton + dessertCarton;
    ResultatDiner =
    $"Minimum : {dinerBtlles} bouteilles pour l'entrée/plat et {dessertBtlles} pour le dessert.\n\n" +
    $"Bouteilles de vin prévues : {Math.Round(blancCarton * 6)} Blanc {Math.Round(blancFruiteCarton * 6)} Blanc fruité {Math.Round(rougeCarton * 6)} Rouge\n" +
    $"Nombre de cartons de blanc sec : {Math.Ceiling(blancCarton)}\n" +
    $"Nombre de cartons de blanc fruité : {Math.Ceiling(blancFruiteCarton)}\n" +
    $"Nombre de cartons de rouge : {Math.Ceiling(rougeCarton)}\n\n" +
    $"Nombre de cartons de mousseux(dessert) : {Math.Ceiling(dessertCarton)}";

    ResultatTotal =
    $"Cartons de mousseux : {Math.Ceiling(mousseuxCarton)}\n" +
    $"Cartons de rosé : {Math.Ceiling(roseCarton)}\n" +
    $"Cartons de blanc sec : {Math.Ceiling(blancCarton)}\n" +
    $"Cartons de blanc fruité : {Math.Ceiling(blancFruiteCarton)}\n" +
    $"Cartons de rouge : {Math.Ceiling(rougeCarton)}\n\n" +
    $"Cartons : {Math.Ceiling(mousseuxCarton) + Math.Ceiling(roseCarton) + Math.Ceiling(blancCarton) + Math.Ceiling(blancFruiteCarton) + Math.Ceiling(rougeCarton)}\n" +
    $"Bouteilles :{(Math.Ceiling(mousseuxCarton) + Math.Ceiling(roseCarton) + Math.Ceiling(blancCarton) + Math.Ceiling(blancFruiteCarton) + Math.Ceiling(rougeCarton)) * 6}";

  }
}


// ajouter un budget si x > y ? ok : hors-budget