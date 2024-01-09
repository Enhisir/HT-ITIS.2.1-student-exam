using System.Diagnostics;
using System.Text.Json;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers;

public class HomeController : Controller
{
    private readonly IGetEnemyService _enemyService;
    private readonly IFightService _fightService;

    public HomeController(
        IGetEnemyService enemyService, 
        IFightService fightService)
    {
        _enemyService = enemyService;
        _fightService = fightService;
    }
    
    [Route("Fight")]
    [HttpPost]
    public IActionResult Fight([FromBody]Character hero)
    {
        var randomMonster = _enemyService.GetEnemy();
        var result = _fightService.Fight(hero, randomMonster);

        return Ok(JsonSerializer.Serialize(result));
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}