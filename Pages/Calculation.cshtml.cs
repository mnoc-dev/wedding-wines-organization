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

    int cocktailVerres = 3 * paxCocktail;
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
    if (roseCarton % 6 >= 1)
    {
      roseCarton++;
    }

    ResultatCocktail =
    $"Minimum :  {cocktailMousseux} bouteilles de mousseux et {Math.Floor(roseBtlles)} de rosé pour le cocktail.\n\n" +
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
    double rougeCarton = (double)(50 * dinerCarton) / 100;
    // Nombre de carton de vins blancs :
    double blancCarton = (double)(30 * dinerCarton) / 100;
    // Nombre de carton de vins blancs fruités :
    double blancFruiteCarton = (double)(20 * dinerCarton) / 100;

    double dessertCarton = dessertBtlles / 6;
    if (dessertBtlles % 6 >= 1)
    {
      dessertCarton++;
    }
    if (blancFruiteCarton <= 1)
    {
      blancFruiteCarton++;
    }
    double mousseuxCarton = cocktailMousseuxCarton + dessertCarton;
    ResultatDiner =
    $"Minimum : {dinerBtlles} bouteilles pour l'entrée/plat et {dessertBtlles} pour le dessert.\n\n" +
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
    $"Cartons : {Math.Ceiling(mousseuxCarton) + Math.Ceiling(roseCarton) + Math.Ceiling(blancCarton) + Math.Ceiling(blancFruiteCarton) + Math.Ceiling(rougeCarton)}";

  }
}
