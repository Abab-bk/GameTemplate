
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;
using System.Text.Json;


namespace cfg
{
public partial struct Vector2
{
    public Vector2(JsonElement _buf) 
    {
        X = _buf.GetProperty("x").GetSingle();
        Y = _buf.GetProperty("y").GetSingle();
    }

    public static Vector2 DeserializeVector2(JsonElement _buf)
    {
        return new Vector2(_buf);
    }

    public readonly float X;
    public readonly float Y;
   

    public  void ResolveRef(Tables tables)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "x:" + X + ","
        + "y:" + Y + ","
        + "}";
    }
}

}
