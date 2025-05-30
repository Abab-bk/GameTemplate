using System;
using Game.Combat;
using Godot;

namespace Game.Commons;

[GlobalClass]
public partial class HitBox : Area2D
{
    public event Action<ProcessedAttack> OnHit = delegate { };

    public Func<Attack> GetAttack { get; private set; } = default!;
    
    public override void _Ready()
    {
        AreaEntered += area =>
        {
            if (area is not HurtBox hurtBox) return;
            
            var result = new ProcessedAttack();
            
            OnHit.Invoke(result);
            hurtBox.OnHurtFunction(result, GetKnockBack());
            
            OnHitPost(hurtBox);
        };
    }

    protected virtual Vector2 GetKnockBack() => Vector2.Zero;
    
    protected virtual void OnHitPost(HurtBox hurtBox)
    {
    }

    public HitBox Config(
        bool isPlayer,
        bool isMob,
        Func<Attack> getAttack
        )
    {
        CallDeferred(CollisionObject2D.MethodName.SetCollisionLayer, 0);
        CallDeferred(CollisionObject2D.MethodName.SetCollisionMask, 0);

        GetAttack = getAttack;
        
        if (isPlayer)
        {
            CallDeferred(CollisionObject2D.MethodName.SetCollisionLayerValue, Layers.Physics2D.PlayerHitBox, true);
            CallDeferred(CollisionObject2D.MethodName.SetCollisionMaskValue, Layers.Physics2D.MobHurtBox, true);
        } else if (isMob)
        {
            CallDeferred(CollisionObject2D.MethodName.SetCollisionLayerValue, Layers.Physics2D.MobHitBox, true);
            CallDeferred(CollisionObject2D.MethodName.SetCollisionMaskValue, Layers.Physics2D.PlayerHurtBox, true);
        }

        return this;
    }
}