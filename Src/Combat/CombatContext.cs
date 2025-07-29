using Game.Stats;

namespace Game.Combat;

public record struct CombatContext(
    Attack Attack,
    ActorStats AttackerStats,
    ActorStats DefenderStats
    );