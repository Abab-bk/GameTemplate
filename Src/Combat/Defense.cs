using DataBase;

namespace Game.Combat;

public record struct Defense(
    DamageType Type,
    float Amount
);