namespace DataBase.Combat;

public readonly record struct ProcessedAttack(
    Damage[] DamageDone,
    Defense[] DefenseDone,
    bool IsCritical
)
{
    public float TotalDamage => DamageDone.Sum(d => d.Amount);
}