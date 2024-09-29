using System.Collections.Generic;
using UnityEditor;

namespace _Project.Editor.EditorSelectionHistory
{
[ InitializeOnLoad ]
static class MultiSelectionHistory
{
    static SelectionHistoryData _activeSelection;


    static bool _ignoreNextSelectionChangedEvent;
    static EditorWindow _lastWindow;

    public static Stack<SelectionHistoryData> PreviousSelections { get; } = new ();

    static readonly Stack<SelectionHistoryData> _nextSelections = new ();

    static MultiSelectionHistory()
    {
        Selection.selectionChanged += OnSelectionChange;
    }

    static void OnSelectionChange()
    {
        if ( _ignoreNextSelectionChangedEvent )
        {
            //while click Back or Forward
            _ignoreNextSelectionChangedEvent = false;
            return;
        }

        if ( _activeSelection != null )
        {
            PreviousSelections.Push( _activeSelection );
        }

        _activeSelection = new SelectionHistoryData( Selection.objects, EditorWindow.focusedWindow );
        _nextSelections.Clear();
    }



    const string BackMenuLabelHotkey = " %[";
    const string ForwardMenuLabelHotkey = " %]";

    const string BackMenuLabel = "Edit/Selection/Multi Back" + BackMenuLabelHotkey;
    const string ForwardMenuLabel = "Edit/Selection/Multi Forward" + ForwardMenuLabelHotkey;

    public static void GoBack( int stepAmount = 1 )
    {
        for ( int i = 0; i < stepAmount; i++ )
        {
            Back();
        }
    }

    [ MenuItem( BackMenuLabel ) ]
    static void Back()
    {
        if ( _activeSelection != null )
        {
            SelectionHistoryData next = new SelectionHistoryData( Selection.objects, EditorWindow.focusedWindow );
            _nextSelections.Push( next );
        }

        SelectionHistoryData prev = PreviousSelections.Pop();
        Selection.objects = prev.Selected;
        OpenWindow( prev.OpenedWindow );

        _ignoreNextSelectionChangedEvent = true;
    }


    [ MenuItem( ForwardMenuLabel ) ]
    static void Forward()
    {
        if ( _activeSelection != null )
        {
            SelectionHistoryData prev = new SelectionHistoryData( Selection.objects, EditorWindow.focusedWindow );
            PreviousSelections.Push( prev );
        }

        SelectionHistoryData next = _nextSelections.Pop();
        Selection.objects = next.Selected;
        OpenWindow( next.OpenedWindow );

        _ignoreNextSelectionChangedEvent = true;
    }

    static void OpenWindow( EditorWindow nextOpenedWindow )
    {
        EditorWindowHelper.GetWindow( nextOpenedWindow );
    }

    [ MenuItem( BackMenuLabel, true ) ]
    static bool ValidateBack() => PreviousSelections.Count > 0;

    [ MenuItem( ForwardMenuLabel, true ) ]
    static bool ValidateForward() => _nextSelections.Count > 0;


}
}