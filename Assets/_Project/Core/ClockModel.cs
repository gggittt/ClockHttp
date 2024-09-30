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
    [SerializeField] float _updatePeriodSeconds = 1;

    const int MoscowTimeShift = 3;

    DateTime _cashedTime;

    void Awake( )
    {
        // DateTime moscowTime = GetMoscowTime();
        DateTime moscowTime = new DateTime( 2024, 9, 29, 23, 59, 49 );
        _cashedTime = moscowTime;

        UpdateUi( moscowTime );

        InvokeRepeating( nameof( OnTimeChange ), 0f, _updatePeriodSeconds );
    }


    void OnTimeChange( )
    {
        _cashedTime = _cashedTime.AddSeconds( _updatePeriodSeconds );
        UpdateUi( _cashedTime );
    }

    void UpdateUi( DateTime time )
    {
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