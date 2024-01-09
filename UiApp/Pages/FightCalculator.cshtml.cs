using System.Text.Json;
using Common.Dtos;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UiApp.Pages;

public class FightCalculator : PageModel
{
    private static string _apiAddress = "http://localhost:5199/Fight";
    
    public string ButtonMessage { get; set; } = "В бой!";

    public FightResult? FightResult { get; set; }
    
    [BindProperty]
    public Character Hero { get; set; }

    public async Task OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            FightResult = new FightResult() { Message = "Неверные данные в форме", Log = new List<MoveInfo>() };
            return;
        }
        var content = JsonContent.Create(Hero);
        
        var client = new HttpClient();
        using var response = await client.PostAsync(_apiAddress, content);
        var responseBody = await response.Content.ReadAsStringAsync();
        FightResult = JsonSerializer.Deserialize<FightResult>(responseBody)!;

        ButtonMessage = FightResult!.Message == Hero.Name ? "В бой!" : "Начать заново";
    }
}