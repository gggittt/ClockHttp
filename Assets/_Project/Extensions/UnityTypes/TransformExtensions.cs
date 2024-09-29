using System.Collections.Generic;
using UnityEngine;

namespace _Project.Extensions.UnityTypes
{
public static class TransformExtensions
{
    public static void Reset( this Transform self )
    {
        self.position = Vector3.zero;
        self.localRotation = Quaternion.identity;
        self.localScale = Vector3.one;
    }

    public static void EnableGameObject( this Transform self )
    {
        self.gameObject.SetActive( true );
    }

    public static void DisableGameObject( this Transform self )
    {
        self.gameObject.SetActive( false );
    }

    public static IEnumerable<Transform> GetParentsAndSelf( this Transform transform )
    {
        //source: ModestTree.Util.UnityUtil.GetParentsAndSelf( transform );

        if ( transform == null )
        {
            yield break;
        }

        yield return transform;

        foreach ( var ancestor in GetParentsAndSelf( transform.parent ) )
        {
            yield return ancestor;
        }
    }
}
}