using UnityEngine;

namespace _Project.Extensions.UnityTypes
{
public static class ObjectExtensions
{
    public static void DestroyItself( this Object self )
    {
        Object.Destroy( self );
    }
}
}