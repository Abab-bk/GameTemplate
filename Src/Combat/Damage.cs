using cfg.Combat;

namespace Game.Combat;

public readonly struct Damage(DamageType type, float amount)
{
    public DamageType Type => type;
    public float Amount => amount;
}