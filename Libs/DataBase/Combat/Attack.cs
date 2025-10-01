namespace DataBase.Combat;

public readonly record struct Attack(
    Damage[] Damages,
    bool IsCritical = false
);