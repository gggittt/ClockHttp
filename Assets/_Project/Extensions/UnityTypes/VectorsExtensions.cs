using UnityEngine;

namespace _Project.Extensions.UnityTypes
{
//to T4, generate same methods from 1 source for: Vector2, v2Int, v3, v3Int, v4
public static class VectorsExtensions
{
    public static Vector3 ToVector3( this Vector2Int self )
    {
        return (Vector2) self;
    }

    /// <summary>
    /// Set X or/and Y, or/and Z
    /// </summary>
    public static Vector3 Set( this Vector3 self, float? x = null, float? y = null, float? z = null )
    {
        return new Vector3( x ?? self.x, y ?? self.y, z ?? self.z );
    }

    public static Vector2Int Add( this Vector2Int self, int? x = null, int? y = null )
    {
        return new Vector2Int( self.x + ( x ?? 0 ), self.y + ( y ?? 0 ));
    }

    public static Vector3 Add( this Vector3 self, float? x = null, float? y = null, float? z = null )
    {
        return new Vector3( self.x + ( x ?? 0 ), self.y + ( y ?? 0 ), self.z + ( z ?? 0 ) );
    }

    public static bool InRangeOf( this Vector3 self, Vector3 target, float range )
    {
        return (self - target).sqrMagnitude <= range * range;
    }
}
}