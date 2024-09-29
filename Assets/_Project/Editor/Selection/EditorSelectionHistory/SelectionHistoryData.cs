using UnityEditor;
using UnityEngine;

namespace _Project.Editor.EditorSelectionHistory
{
public class SelectionHistoryData
{
    public Object[] Selected;
    public EditorWindow OpenedWindow;

    public SelectionHistoryData( Object[] selected, EditorWindow openedWindow )
    {
        Selected = selected;
        OpenedWindow = openedWindow;
    }
}
}