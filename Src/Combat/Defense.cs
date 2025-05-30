using cfg.Combat;

namespace Game.Combat;

public readonly struct Defense(DefenseType type, float amount)
{
    public DefenseType Type => type;
    public float Amount => amount;
}