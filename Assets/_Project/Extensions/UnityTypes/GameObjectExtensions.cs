using UnityEngine;

namespace _Project.Extensions.UnityTypes
{
public static class GameObjectExtensions
{
    /// <summary>
    /// self.SetActive( true );
    /// </summary>
    public static void Enable( this GameObject self )
    {
        self.SetActive( true );
    }
    /// <summary>
    /// self.SetActive( false );
    /// </summary>
    public static void Disable( this GameObject self )
    {
        self.SetActive( false );
    }
}
}