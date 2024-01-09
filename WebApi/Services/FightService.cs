using Common.Dtos;
using Common.Models;

namespace WebApi.Services;

public class FightService : IFightService
{
    public FightResult Fight(Character first, Character second)
    {
        var currentAttacker = first;
        var currentVictim = second;
        var result = new FightResult() { Log = new List<MoveInfo>() };
        while (first.HitPoints > 0 && second.HitPoints > 0)
        {
            for (var attackCount = 0; attackCount < currentAttacker.AttackNumberPerRound 
                                      && currentVictim.HitPoints > 0; attackCount++)
                if (currentAttacker != null)
                    result.Log.Add(MakeMove(currentAttacker, currentVictim));

            if (currentVictim.HitPoints <= 0)
                result.Message = $"Победитель: {currentAttacker.Name}";
            (currentAttacker, currentVictim) = (currentVictim, currentAttacker);
        }

        return result;
    }

    private MoveInfo MakeMove(Character attacker, Character victim)
    {
        var random = new Random();
        var move = new MoveInfo()
        {
            AttackerName = attacker.Name,
            AttackModifier = attacker.AttackModifier,
            Attack = random.Next(1, 21),
            VictimName = victim.Name,
            VictimArmorClass = victim.ArmorClass,
        };
        if (!move.IsHit) return move;

        move.Damage = random.Next(1, attacker.MaxCubeDamage + 1) * attacker.CubeDamageMultiplier;
        move.DamageModifier = attacker.DamageModifier;

        var hit = move.Damage.Value + move.DamageModifier.Value * (move.IsCriticalHit ? 2 : 1);
        victim.HitPoints -= hit;
        move.VictimHealthAfterAttack = victim.HitPoints;
        return move;
    }
}