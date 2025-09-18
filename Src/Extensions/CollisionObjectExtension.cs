using Godot;

namespace Game.Extensions;

public static class CollisionObjectExtension
{
    public static CollisionObject2D SetLayerCallDeferred(this CollisionObject2D obj, uint layer)
    {
        obj.CallDeferred(CollisionObject2D.MethodName.SetCollisionLayer, layer);
        return obj;
    }

    public static CollisionObject2D SetMaskCallDeferred(this CollisionObject2D obj, uint mask)
    {
        obj.CallDeferred(CollisionObject2D.MethodName.SetCollisionMask, mask);
        return obj;
    }
}