using System.Text;

namespace Common.Dtos;

public class MoveInfo
{
    public string AttackerName { get; set; }
    public string VictimName { get; set; }
    public int Attack { get; set; }
    public int AttackModifier { get; set; }
    public int VictimArmorClass { get; set; }
    public int? Damage { get; set; }
    public int? DamageModifier { get; set; }
    public int? VictimHealthAfterAttack { get; set; }

    public bool IsHit => Attack > 1 && (Attack == 20 || Attack + AttackModifier >= VictimArmorClass);
    public bool IsCriticalHit => Attack == 20;
    public bool IsCriticalFail => Attack == 1;

    public override string ToString()
    {
        var builder = new StringBuilder();
        var beautifulAttackModifier = AttackModifier > 0 ? $"+{AttackModifier}" : AttackModifier.ToString();
        var attackResult =
            IsHit
                ? (IsCriticalHit
                    ? "критическое попадание"
                    : "попадание")
                : (IsCriticalFail
                    ? "критический промах"
                    : "промах");
        builder.Append($"{AttackerName}: {Attack} ({beautifulAttackModifier}), {attackResult}.");

        if (!IsHit) return builder.ToString();

        var beautifulDamageModifier = DamageModifier > 0 ? $"+{DamageModifier}" : DamageModifier.ToString();
        var beautifulCriticalMultiplier = IsCriticalHit ? "* 2" : string.Empty;
        var hit = Damage!.Value + DamageModifier!.Value * (IsCriticalHit ? 2 : 1);
        builder.Append(
            $" {Damage} ({beautifulDamageModifier}) {beautifulCriticalMultiplier} наносит {hit} урона по {VictimName}");
        return builder.ToString();
    }
}