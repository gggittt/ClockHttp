using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using Zenject;

[InitializeOnLoad]
public static class AfterCompilation
{
    static AfterCompilation( )
    {
        Selection.activeObject = Object.FindObjectOfType<SceneContext>();
    }

}
#endif