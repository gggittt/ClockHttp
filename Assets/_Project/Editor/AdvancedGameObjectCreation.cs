using System;
using UnityEditor;
using UnityEngine;

namespace _Project.Editor
{
public static class AdvancedGameObjectCreation
{
    public static GameObject CreateAndRename( string name, string undoRegisterName = "Created game object" )
    {
        GameObject createdGo = new GameObject( name );
        TrySetActiveGameObjectAsParent( createdGo );

        Selection.activeGameObject = createdGo;

        Undo.RegisterCreatedObjectUndo( createdGo, undoRegisterName );

        EditorApplication.delayCall += Rename;

        return createdGo;
    }

    static void Rename( )
    {
        Type sceneHierarchyType = Type.GetType( "UnityEditor.SceneHierarchyWindow,UnityEditor" );
        EditorWindow hierarchyWindow = EditorWindow.GetWindow( sceneHierarchyType );
        hierarchyWindow.SendEvent( EditorGUIUtility.CommandEvent( "Rename" ) );
    }

    static void TrySetActiveGameObjectAsParent( GameObject createdGo )
    {
        if ( !Selection.activeGameObject )
            return;

        createdGo.transform.SetParent( Selection.activeGameObject.transform );
    }
}
}
