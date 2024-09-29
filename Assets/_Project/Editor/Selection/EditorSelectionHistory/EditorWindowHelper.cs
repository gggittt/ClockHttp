using System;
using System.Reflection;
using UnityEditor;

namespace _Project.Editor.EditorSelectionHistory
{

public static class EditorWindowHelper
{
    public static EditorWindow GetWindow( EditorWindow window )
    {
        string windowName = window.ToString()
               .Replace( "(", "" )
               .Replace( ")", "" )
            ;

        Assembly assembly = typeof( EditorWindow ).Assembly;
        Type type = assembly.GetType( windowName );
        return UnityEditor.EditorWindow.GetWindow( type );

    }
}
}