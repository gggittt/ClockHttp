using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace SimpleFolderIcon.Editor
{
public class IconDictionaryCreator : AssetPostprocessor
{
    const string AssetsPath = "_Project/Editor/SimpleFolderIcon/Icons"; //fixme получать относительный путь от скрипта
    // const string AssetsPath = "Tools/SimpleFolderIcon/Icons";
    const string PathWithTopFolder = "Assets/" + AssetsPath;
    internal static Dictionary<string, Texture> IconDictionary;

    static void OnPostprocessAllAssets( string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths )
    {
        if ( !ContainsIconAsset( importedAssets ) &&
             !ContainsIconAsset( deletedAssets ) &&
             !ContainsIconAsset( movedAssets ) &&
             !ContainsIconAsset( movedFromAssetPaths )
           )
        {
            return;
        }

        BuildDictionary();
    }

    static bool ContainsIconAsset( string[] assets )
    {
        foreach ( string str in assets )
        {
            if ( ReplaceSeparatorChar( System.IO.Path.GetDirectoryName( str ) ) == PathWithTopFolder )
            {
                return true;
            }
        }

        return false;
    }

    static string ReplaceSeparatorChar( string path )
    {
        return path.Replace( "\\", "/" );
    }

    internal static void BuildDictionary( )
    {
        Dictionary<string, Texture> dictionary = new Dictionary<string, Texture>();

        DirectoryInfo dir = new DirectoryInfo( Application.dataPath + "/" + AssetsPath );
        FileInfo[] info = dir.GetFiles( "*.png" );
        foreach ( FileInfo f in info )
        {
            Texture texture = (Texture) AssetDatabase.LoadAssetAtPath( $"{PathWithTopFolder}/{f.Name}", typeof( Texture2D ) );
            string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension( f.Name );
            dictionary.Add( fileNameWithoutExtension, texture );

            // TryAddWithPartialOverlap( fileNameWithoutExtension );
        }

        IconDictionary = dictionary;
    }

    static readonly string[] _wordsInFolderName = { "HUD", "Project", "Packages", };

    static void TryAddWithPartialOverlap( string fileName )
    {
        foreach ( string tag in _wordsInFolderName )
        {
            if ( fileName.Contains( tag ) )
            {

            }
        }
    }
}
}