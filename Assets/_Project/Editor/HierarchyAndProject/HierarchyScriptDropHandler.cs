using System.Collections.Generic;
using _Project.Editor;
using Sirenix.Utilities;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class HierarchyScriptDropHandler
{
    static HierarchyScriptDropHandler( )
    {
        // DragAndDrop.AddDropHandler implemented in unity versions  >2021.2

        DragAndDrop.AddDropHandler( OnScriptDropToHierarchy );
    }

    static DragAndDropVisualMode OnScriptDropToHierarchy( int dropTargetInstanceID, HierarchyDropFlags dropMode, Transform parentForDraggedObjects, bool perform )
    {
        List<MonoScript> monoScripts = GetDraggedScripts();

        if ( monoScripts.ToArray().IsNullOrEmpty() )
            return DragAndDropVisualMode.None;

        if ( perform ) //perform = When releasing LMB
        {
            CreateScripts( monoScripts );
        }

        return DragAndDropVisualMode.Copy;
    }

    static void CreateScripts( List<MonoScript> monoScripts )
    {
        foreach ( MonoScript monoScript in monoScripts )
        {
            GameObject gameObject = AdvancedGameObjectCreation
               .CreateAndRename( monoScript.name, "Created game object from HierarchyScriptDrop" );

            gameObject.AddComponent( monoScript.GetClass() );
        }
    }

    static List<MonoScript> GetDraggedScripts( )
    {
        List<MonoScript> monoScripts = new();
        foreach ( Object dragged in DragAndDrop.objectReferences )
        {
            if ( dragged is not MonoScript monoScript )
                continue;

            System.Type scriptType = monoScript.GetClass();
            bool isMonoBehaviour = CanCreateMonoBehaviourInstance( scriptType );
            if ( isMonoBehaviour )
            {
                monoScripts.Add( monoScript );
            }
        }

        return monoScripts;
    }

    static bool CanCreateMonoBehaviourInstance( System.Type type )
    {
        return type != null
               && type.IsSubclassOf( typeof( MonoBehaviour ) )
               && !type.IsAbstract
               && !type.ContainsGenericParameters;
    }

}