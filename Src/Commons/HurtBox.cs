using System;
using Game.Combat;
using Godot;

namespace Game.Commons;

[GlobalClass]
public partial class HurtBox : Area2D
{
    public event Action<ProcessedAttack, Vector2> OnHurt = delegate { };

    public void Hurt(
        ProcessedAttack processedAttack,
        Vector2 direction
    )
    {
        OnHurt.Invoke(processedAttack, direction);
    }

    public HurtBox Config(
        bool isPlayer,
        bool isMob
    )
    {
        var layer = isPlayer ?
            Layers.Physics2D.PlayerHurtBox :
            Layers.Physics2D.MobHurtBox;
        
        var mask = isPlayer ?
            Layers.Physics2D.Mask.PlayerHitBox :
            Layers.Physics2D.Mask.MobHitBox;
        
        CallDeferred(CollisionObject2D.MethodName.SetCollisionLayer, Layers.GetLayer(layer));
        CallDeferred(CollisionObject2D.MethodName.SetCollisionMask, mask);

        return this;
    }
}