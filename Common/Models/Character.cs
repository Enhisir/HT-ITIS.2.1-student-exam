using System.ComponentModel.DataAnnotations;

namespace Common.Models;

public class Character
{
   public int Id { get; set; }
   [Required]
   public string Name { get; set; }
   [Required]
   [Range(typeof(int), "1", "100")]
   public int HitPoints { get; set; }
   [Range(typeof(int), "1", "100")]
   public int ArmorClass { get; set; }
   
   [Range(typeof(int), "1", "10")]
   public int AttackNumberPerRound { get; set; }
   [Range(typeof(int), "0", "100")]
   public int AttackModifier { get; set; }
   [Range(typeof(int), "0", "100")]
   public int DamageModifier { get; set; }
   
   [Range(typeof(int), "1", "20")]
   public int MaxCubeDamage { get; set; }
   [Range(typeof(int), "1", "10")]
   public int CubeDamageMultiplier { get; set; }
}