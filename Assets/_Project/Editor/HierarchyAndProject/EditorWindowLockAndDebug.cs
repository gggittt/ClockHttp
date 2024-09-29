using System;
using System.Reflection;
using UnityEditor;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using Object = UnityEngine.Object;

public static class EditorWindowLockAndDebug
{
    static EditorWindow _activeProject;


    [Shortcut( nameof( EditorWindowLockAndDebug ) + nameof( ToggleInspectorDebugMode ), KeyCode.Space, ShortcutModifiers.Alt | ShortcutModifiers.None )]
    static void ToggleInspectorDebugMode( )
    {
        ActiveEditorTracker activeEditorTracker = ActiveEditorTracker.sharedTracker;

        switch ( activeEditorTracker.inspectorMode )
        {
            case InspectorMode.Normal:
                activeEditorTracker.inspectorMode = InspectorMode.Debug;
                break;
            case InspectorMode.Debug:
                activeEditorTracker.inspectorMode = InspectorMode.Normal;
                break;
            case InspectorMode.DebugInternal:
                Debug.Log( $"<color=cyan> {InspectorMode.DebugInternal} </color>" );
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        activeEditorTracker.ForceRebuild();
    }

    [Shortcut( nameof( EditorWindowLockAndDebug ) + nameof( ToggleInspectorLock ), KeyCode.Space, ShortcutModifiers.Control )]
    static void ToggleInspectorLock( )
    {
        ActiveEditorTracker.sharedTracker.isLocked = !ActiveEditorTracker.sharedTracker.isLocked;
        ActiveEditorTracker.sharedTracker.ForceRebuild();
    }

    [Shortcut( nameof( EditorWindowLockAndDebug ) + nameof( ToggleProjectLock ), KeyCode.Space, ShortcutModifiers.Control | ShortcutModifiers.Shift )]
    static void ToggleProjectLock( )
    {
        if ( _activeProject == null )
        {
            Type type = Assembly.GetAssembly( typeof( UnityEditor.Editor ) )
               .GetType( "UnityEditor.ProjectBrowser" );
            Object[] findObjectsOfTypeAll = Resources.FindObjectsOfTypeAll( type );
            _activeProject = (EditorWindow) findObjectsOfTypeAll[ 0 ];
        }

        if ( _activeProject == null || _activeProject.GetType().Name != "ProjectBrowser" )
            return;

        {
            Type type = Assembly.GetAssembly( typeof( UnityEditor.Editor ) ).GetType( "UnityEditor.ProjectBrowser" );
            PropertyInfo propertyInfo = type.GetProperty( "isLocked"
              , BindingFlags.Instance |
                BindingFlags.NonPublic |
                BindingFlags.Public );

            bool value = (bool) propertyInfo.GetValue( _activeProject, null );

            propertyInfo.SetValue( _activeProject, !value, null );

            _activeProject.Repaint();
        }
    }
}