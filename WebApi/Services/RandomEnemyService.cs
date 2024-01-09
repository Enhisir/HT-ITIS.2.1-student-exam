using Common.Models;
using Microsoft.EntityFrameworkCore;
using WebApi.Db;

namespace WebApi.Services;

public class RandomEnemyService : IGetEnemyService
{
    private readonly ApplicationContext _dbContext;
    public RandomEnemyService(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Character GetEnemy() => 
        _dbContext.Monsters.OrderBy(r => EF.Functions.Random()).Take(1).First();
}