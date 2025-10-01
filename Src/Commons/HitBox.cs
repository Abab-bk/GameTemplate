using System;
using Core.Combat;
using Godot;

namespace Game.Commons;

[GlobalClass]
public partial class HitBox : Area2D
{
    public Attack Attack { get; set; }
    public event Action<ProcessedAttack> OnHit = delegate { };

    public override void _Ready()
    {
        Connect(
            Area2D.SignalName.AreaEntered,
            Callable.From((Area2D area) =>
            {
                if (area is not HurtBox hurtBox) return;

                var result = new ProcessedAttack();
                OnHit.Invoke(result);

                hurtBox.Hurt(result, GetKnockBack());

                OnHitPost(hurtBox);
            })
        );
    }

    protected virtual Vector2 GetKnockBack()
    {
        return Vector2.Zero;
    }

    protected virtual void OnHitPost(HurtBox hurtBox)
    {
    }

    public HitBox Config(bool isPlayer, Attack attack)
    {
        var layer = isPlayer ? Layers.Physics2D.Mask.PlayerHitBox : Layers.Physics2D.Mask.MobHitBox;
        var mask = isPlayer ? Layers.Physics2D.Mask.MobHurtBox : Layers.Physics2D.Mask.PlayerHurtBox;

        CallDeferred(CollisionObject2D.MethodName.SetCollisionLayer, layer);
        CallDeferred(CollisionObject2D.MethodName.SetCollisionMask, mask);

        Attack = attack;

        return this;
    }
}