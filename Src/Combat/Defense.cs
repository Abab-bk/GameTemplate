using cfg.Combat;

namespace Game.Combat;

public record struct Defense(
    DamageType Type,
    float Amount
    );