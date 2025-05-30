using System.Collections.Generic;
using cfg.Combat;

namespace Game.Combat;

public readonly struct Attack(
    IEnumerable<Damage> damages,
    bool isCritical = false,
    DamageType statusType = DamageType.Normal
    )
{
    public bool IsCritical => isCritical;
    public DamageType StatusType => statusType;
    public readonly IEnumerable<Damage> Damages => damages;
}