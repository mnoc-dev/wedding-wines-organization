using Microsoft.AspNetCore.Mvc.RazorPages;
// base des pages .cshtml.cs
using System.Net.Http.Headers;
// gère les headers HTTP
using System.Text.Json;
// pour manipuler du JSON (rep API en JSON puis C#)
public class WinePairingModel : PageModel
// nom de la page backend
{
  private readonly HttpClient _httpClient;
  // une variable privée - HttpClient = outil pour appeler API
  public string ApiResult { get; set; }
  // Sert à afficher le résultat

  public WinePairingModel(HttpClient httpClient)
  // methode appelee quand la page est créé
  // ASP.NET injecte HttpClient (dependency injection)
  {
    _httpClient = httpClient;
    // stocke l'objet injecté dans notre variable privée
    // can use partout dans la classe
  }

  public async Task OnGetAsync()
  // methode appelée quand l'user ouvre la page
  // OnGet = req HTTP Get
  // Async = ne bloque pas le serveur
  // Task  = retour async
  {
    //  Ajout du token API
    _httpClient.DefaultRequestHeaders.Authorization =
        // ajoute un header HTTP
        new AuthenticationHeaderValue("Bearer", "GMLVCJKOJEAA-aREBhRxZx8YMOkPRumL264YlxVpKqPMV02IYTXNRWkNE2zTT");
    // Construction du header, Bearer = type d'auth, TOKEN = clé API
    //  appel API
    var response = await _httpClient.GetAsync("https://api.grapeminds.eu/public/v1/region-insights/210?lang=de");
    // Envoie une req HTTP GET, await = attend la rep sans bloqué, GetAsync = req GET, URL = endpoint API
    if (response.IsSuccessStatusCode)
    // Verif si API répond correctement
    {
      ApiResult = await response.Content.ReadAsStringAsync();
      // récup rep brute, JSON transformé en string et stocké dans ApiResult
    }
    else
    {
      ApiResult = "Erreur API";
    }
  }
}