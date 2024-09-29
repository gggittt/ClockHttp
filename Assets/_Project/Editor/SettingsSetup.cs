using UnityEditor;
using UnityEngine;

namespace _Project.Editor
{

public static class SettingsSetup
{
    [MenuItem( EditorConstants.SetupMenuFolder + nameof( InitAllSettings ) )]
    static void InitAllSettings( )
    {
        Debug.Log( $"<color=cyan> {nameof( SettingsSetup )}.{nameof( InitAllSettings )} </color>" );

        EnableFastEnterPlayMode();
        static void EnableFastEnterPlayMode( )
        {
            EditorSettings.enterPlayModeOptionsEnabled = true;
            Debug.Log( nameof( EditorSettings.enterPlayModeOptionsEnabled ) + " Enabled" );
        }

        SetUnityRemoteDevice("Any Android Device");
        static void SetUnityRemoteDevice( string device )
        {
            Debug.Log( $"{nameof( EditorSettings.unityRemoteDevice )} changed from {EditorSettings.unityRemoteDevice} to: <color=cyan> {device} </color>" );

            EditorSettings.unityRemoteDevice = device;
        }
    }

}
}