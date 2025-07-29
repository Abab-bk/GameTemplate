using cfg.Combat;

namespace Game.Combat;

public readonly record struct Damage(
    DamageType Type,
    float Amount
    );