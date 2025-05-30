using System.Collections.Generic;
using System.Linq;

namespace Game.Combat;

public readonly struct ProcessedAttack(
    IEnumerable<Damage> damageDone,
    IEnumerable<Defense> defenseDone,
    bool isCritical
    )
{
    public bool IsCritical => isCritical;
    public IEnumerable<Damage> DamageDone => damageDone;
    public IEnumerable<Defense> DefenseDone => defenseDone;
    
    public float Damage => damageDone.Sum(d => d.Amount);

    public override string ToString()
    {
        return $"Damage Done: {DamageDone.Sum(d => d.Amount)}\n" +
               $"Defense Done: {DefenseDone.Sum(d => d.Amount)}\n";
    }
}