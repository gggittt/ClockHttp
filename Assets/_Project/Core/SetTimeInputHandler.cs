using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Core
{
public class SetTimeInputHandler : MonoBehaviour
{
    [SerializeField] ClockModel _clockModel;

    [SerializeField] TMP_InputField _hours;
    [SerializeField] TMP_InputField _minutes;
    [SerializeField] TMP_InputField _seconds;

    [SerializeField] Button _submitTimeChangingButton;

    void Awake( )
    {
        _submitTimeChangingButton.onClick.AddListener( HandleInputs );
    }

    void HandleInputs( )
    {
        if ( int.TryParse( _seconds.text, out int parsedSeconds ) == false )
        {
            return;
        }

        if ( int.TryParse( _minutes.text, out int parsedMinutes ) == false )
        {
            return;
        }

        if ( int.TryParse( _hours.text, out int parsedHours ) == false )
        {
            return;
        }

        DateTime now = DateTime.Now;
        _clockModel.SetTime( new DateTime( now.Year, now.Month, now.Day, parsedHours, parsedMinutes, parsedSeconds ) );
    }

    void OnDestroy( )
    {
        _submitTimeChangingButton.onClick.RemoveAllListeners();
    }
}
}