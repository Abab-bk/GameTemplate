
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
public partial struct vector2
{
    public vector2(JsonElement _buf) 
    {
        X = _buf.GetProperty("x").GetSingle();
        Y = _buf.GetProperty("y").GetSingle();
    }

    public static vector2 Deserializevector2(JsonElement _buf)
    {
        return new vector2(_buf);
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

