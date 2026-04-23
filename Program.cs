var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();


int paxCocktail = 80;
int paxDiner = 70;
int verre = 1;
double bouteille = 6.5 * verre;

// Cocktail Mousseux Rosé :

// Partir sur 3 verres d’alcool par personne
//  (Mousseux : 6.5 verres dans 1 bouteille)

int cocktailVerres = 3 * paxCocktail;
double cocktailBtlles = (double)cocktailVerres / bouteille;


// Rosé 20 % de cocktailBtlles
double roseBtlles = (double)(20 * cocktailBtlles) / 100;
Console.WriteLine($"Il faut {Math.Floor(cocktailBtlles)} bouteilles de mousseux dont {Math.Floor(roseBtlles)} de rosé pour le cocktail");
int cocktailMousseux = (int)(cocktailBtlles - roseBtlles);
// prendre un carton au dessus
double cocktailMousseuxCarton = cocktailBtlles / 6;
if (cocktailBtlles % 6 >= 3)
{
  cocktailMousseuxCarton++;
}
Console.WriteLine("Nombre de carton de Mousseux pour le cocktail : " + Math.Floor(cocktailMousseuxCarton));
Console.WriteLine("Nombre de carton de Rosé pour le cocktail : " + Math.Floor(roseBtlles / 6));
// Diner Rouge Blanc

// Partir sur 1 bttle de vin pour 3 personnes 
// Bulles pour le dessert : compter 1 bouteille pour 6 personnes

// vins :

int dinerBtlles = paxDiner / 3;
int dessertBtlles = paxDiner / 6;
Console.WriteLine($" vins au repas {dinerBtlles} et mousseux pour dessert {dessertBtlles} pour {paxDiner} personnes.");

// prendre un carton au dessus
double dinerCarton = dinerBtlles / 6;
if (dinerBtlles % 6 >= 3)
{
  dinerCarton++;
}
Console.WriteLine("Nombre de carton pour le repas : " + dinerCarton);

double dessertCarton = dessertBtlles / 6;
if (dessertBtlles % 6 >= 3)
{
  dessertCarton++;
}
// 100 = 50 % rouge + 20% Blanc sec + 10% blanc fruité  + 10% mousseux(dessert)
Console.WriteLine("Nombre de carton pour le dessert : " + dessertCarton);
app.Run();