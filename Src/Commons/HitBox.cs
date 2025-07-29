using System;
using Game.Combat;
using Godot;

namespace Game.Commons;

[GlobalClass]
public partial class HitBox : Area2D
{
    public event Action<ProcessedAttack> OnHit = delegate { };
    
    public Attack Attack { get; set; }

    public override void _Ready()
    {
        AreaEntered += area =>
        {
            if (area is not HurtBox hurtBox) return;

            var result = new ProcessedAttack();
            OnHit.Invoke(result);
            
            hurtBox.Hurt(result, GetKnockBack());

            OnHitPost(hurtBox);
        };
    }

    protected virtual Vector2 GetKnockBack()
    {
        return Vector2.Zero;
    }

    protected virtual void OnHitPost(HurtBox hurtBox)
    {
    }

    public HitBox Config(
        bool isPlayer,
        bool isMob,
        Attack attack
    )
    {
        var layer = isPlayer ?
            Layers.Physics2D.PlayerHitBox :
            Layers.Physics2D.MobHitBox;
        
        var mask = isPlayer ?
            Layers.Physics2D.Mask.MobHurtBox :
            Layers.Physics2D.Mask.PlayerHurtBox;
        
        CallDeferred(CollisionObject2D.MethodName.SetCollisionLayer, Layers.GetLayer(layer));
        CallDeferred(CollisionObject2D.MethodName.SetCollisionMask, mask);

        Attack = attack;
        
        return this;
    }
}