using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Db;

public sealed class ApplicationContext : DbContext
{
    public DbSet<Character> Monsters { get; set; } = null!;
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();   // создаем базу данных при первом обращении
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>()
            .HasData(
            new Character
            {
                Id = 1,
                Name = "Гоблин", 
                HitPoints = 7, 
                ArmorClass = 15, 
                AttackModifier = 1, 
                DamageModifier = -1,
                MaxCubeDamage = 6,
                CubeDamageMultiplier= 1,
                AttackNumberPerRound = 1
            },
            new Character
            {
                Id = 2,
                Name = "Ледяная Жаба", 
                HitPoints = 32, 
                ArmorClass = 12, 
                AttackModifier = 3, 
                DamageModifier = 1,
                MaxCubeDamage = 8,
                CubeDamageMultiplier= 1,
                AttackNumberPerRound = 1
            },
            new Character
            {
                Id = 3,
                Name = "Орк", 
                HitPoints = 15, 
                ArmorClass = 13, 
                AttackModifier = 5, 
                DamageModifier = 3,
                MaxCubeDamage = 12,
                CubeDamageMultiplier= 1,
                AttackNumberPerRound = 1
            }
        );
    }
}