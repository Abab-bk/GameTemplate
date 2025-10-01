namespace DataBase.Combat;

public readonly record struct Damage(
    DamageType Type,
    float Amount
);