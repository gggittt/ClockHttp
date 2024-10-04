using System;
using _Project.Core.HttpRequests.YandexTimeRequest;
using _Project.Core.View;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Core
{
public class ClockModel : MonoBehaviour
{
    [SerializeField] YandexTimeProvider _yandex;
    [SerializeField] NumericClockView _numericClockView;
    [SerializeField] AnalogClockView _analogClockView;

    [SerializeField] float _localUpdatePeriodSeconds = 1;
    [SerializeField] int _secondsBetweenServerSync = 3600;
    [SerializeField] bool _mockWithoutHttpRequest;

    const int MoscowTimeShift = 3;

    DateTime _cashedTime;

    public void SetTime( DateTime newDateTime )
    {
        _cashedTime = newDateTime;
        UpdateUi( newDateTime );
    }

    void Awake( )
    {
        if ( _mockWithoutHttpRequest )
            _cashedTime = new DateTime( 2024, 9, 29, 23, 59, 55 );
        else
            SetMoscowTime();

        UpdateUi();

        InvokeRepeating( nameof( TickLocallyRepeating ), 0f, _localUpdatePeriodSeconds );
        InvokeRepeating( nameof( SyncTimeWithWebRequest ), 0f, _secondsBetweenServerSync );
    }

    void SetMoscowTime( )
    {
        _cashedTime = GetMoscowTime();
    }

    void SyncTimeWithWebRequest( )
    {
        SetMoscowTime();
        UpdateUi();
    }

    void TickLocallyRepeating( )
    {
        _cashedTime = _cashedTime.AddSeconds( _localUpdatePeriodSeconds );
        UpdateUi();
    }

    void UpdateUi( )
    {
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

    DateTime GetMoscowTime( )
    {
        DateTime utcDateTime = _yandex.GetCurrentUtcDateTime();

        DateTime moscowTime = utcDateTime.AddHours( MoscowTimeShift );

        Debug.Log( $"<color=cyan> {moscowTime} </color>" );
        return moscowTime;
    }

    [Button]
    void LogMoscowTime( )
    {
        Debug.Log( $"<color=cyan> {GetMoscowTime()} </color>" );
    }
}
}