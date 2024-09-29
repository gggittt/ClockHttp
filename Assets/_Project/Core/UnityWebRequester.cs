using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Core
{
public class UnityWebRequester : MonoBehaviour
{
    [Button]
    public void Test( )
    {
        Debug.Log( $"<color=cyan> {nameof( Test )} </color>" );

    }
}
}