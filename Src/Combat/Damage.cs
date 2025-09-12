using DataBase;

namespace Game.Combat;

public readonly record struct Damage(
    DamageType Type,
    float Amount
    );