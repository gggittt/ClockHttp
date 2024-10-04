using System;
using _Project.Core.YandexTimeRequest;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Core
{
public class ClockModel : MonoBehaviour
{
    [SerializeField] YandexTimeProvider _yandex;
    [SerializeField] NumericClockView _numericClockView;
    [SerializeField] AnalogClockView _analogClockView;

    [SerializeField] float _updatePeriodSeconds = 1;
    [SerializeField] bool _mockWithoutHttpRequest;

    const int MoscowTimeShift = 3;

    // TimeSpan _cashedTime;
    DateTime _cashedTime;

    public void SetTime( DateTime newDateTime )
    {
        _cashedTime = newDateTime;
        UpdateUi( newDateTime );
    }

    void Awake( )
    {
        DateTime time;

        if ( _mockWithoutHttpRequest )
            time = new DateTime( 2024, 9, 29, 23, 59, 55 );
        else
            time = GetMoscowTime();

        _cashedTime = time;

        UpdateUi( time );

        InvokeRepeating( nameof( UpdateTimeRepeating ), 0f, _updatePeriodSeconds );
    }

    void UpdateTimeRepeating( )
    {
        _cashedTime = _cashedTime.AddSeconds( _updatePeriodSeconds );
        UpdateUi( _cashedTime );
    }

    void UpdateUi( DateTime time )
    {
        _analogClockView.Set(
            hour: time.Hour,
            minute: time.Minute,
            second: time.Second
        );
        _numericClockView.Set(
            hour: time.Hour.ToString(),
            minute: time.Minute.ToString(),
            second: time.Second.ToString()
        );
    }

    [Button]
    DateTime GetMoscowTime( )
    {
        DateTime utcDateTime = _yandex.GetCurrentUtcDateTime();

        DateTime moscowTime = utcDateTime.AddHours( MoscowTimeShift );

        Debug.Log( $"<color=cyan> {moscowTime} </color>" );
        return moscowTime;
    }
}

}