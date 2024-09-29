using UnityEngine;

namespace _Project.Extensions.UnityTypes
{
public static class MonoBehaviourExtensions
{
    public static void Enable( this MonoBehaviour self )
    {
        self.enabled = true;
    }

    public static void Disable( this MonoBehaviour self )
    {
        self.enabled = false;
    }

    public static void EnableGameObject( this MonoBehaviour self )
    {
        self.gameObject.SetActive( true );
    }

    public static void DisableGameObject( this MonoBehaviour self )
    {
        self.gameObject.SetActive( false );
    }

    public static void DestroyGameObject( this MonoBehaviour self )
    {
        Object.Destroy( self.gameObject );
    }
}
}