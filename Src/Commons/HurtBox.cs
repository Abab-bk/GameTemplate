using System;
using Game.Combat;
using Godot;

namespace Game.Commons;

[GlobalClass]
public partial class HurtBox : Area2D
{
    public event Action<ProcessedAttack, Vector2> OnHurt = delegate { };
    
    public void OnHurtFunction(
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
        CallDeferred(CollisionObject2D.MethodName.SetCollisionLayer, 0);
        CallDeferred(CollisionObject2D.MethodName.SetCollisionMask, 0);
        
        if (isPlayer)
        {
            CallDeferred(CollisionObject2D.MethodName.SetCollisionLayerValue, Layers.Physics2D.PlayerHurtBox, true);
            CallDeferred(CollisionObject2D.MethodName.SetCollisionMaskValue, Layers.Physics2D.MobHitBox, true);
        } else if (isMob)
        {
            CallDeferred(CollisionObject2D.MethodName.SetCollisionLayerValue, Layers.Physics2D.MobHurtBox, true);
            CallDeferred(CollisionObject2D.MethodName.SetCollisionMaskValue, Layers.Physics2D.PlayerHitBox, true);
        }

        return this;
    }
}