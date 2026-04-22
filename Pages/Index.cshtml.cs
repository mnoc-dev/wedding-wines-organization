using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace firstProjectCSharp.Pages;

public class IndexModel : PageModel
{
    public void OnGet()
    {

        int paxCocktail = 80;
        int paxDiner = 70;
        int verre = 1;
        double bouteille = 6.5 * verre;

        // Cocktail Mousseux Rosé :

        // Partir sur 3 verres d’alcool par personne
        //  (Mousseux : 6 verres dans 1 bouteille)

        int cocktailVerres = 3 * paxCocktail;
        double cocktailBtlles = (double)cocktailVerres / bouteille;

        Console.WriteLine(cocktailBtlles);
    }
}
