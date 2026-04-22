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
//  (Mousseux : 6 verres dans 1 bouteille)

int cocktailVerres = 3 * paxCocktail;
double cocktailBtlles = (double)cocktailVerres / bouteille;

Console.WriteLine($"Il faut {Math.Ceiling(cocktailBtlles)} bouteilles de mousseux ou rosé pour le cocktail");
app.Run();