using Godot;

namespace AcidUtilities;

public static class CollisionObjectExtension
{
    public static CollisionObject2D SetLayer(this CollisionObject2D obj, int layer, bool enabled)
    {
        obj.SetCollisionLayerValue(layer, enabled);
        return obj;
    }
    
    public static CollisionObject2D SetMask(this CollisionObject2D obj, int mask, bool enabled)
    {
        obj.SetCollisionMaskValue(mask, enabled);
        return obj;
    }
    
    public static CollisionObject2D CleanLayer(this CollisionObject2D obj)
    {
        obj.CollisionLayer = 0;
        return obj;
    }
    
    public static CollisionObject2D CleanMask(this CollisionObject2D obj)
    {
        obj.CollisionMask = 0;
        return obj;
    }
    
    public static CollisionObject2D CleanAll(this CollisionObject2D obj)
    {
        obj.CleanLayer();
        obj.CleanMask();
        return obj;
    }
}