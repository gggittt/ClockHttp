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

    const int MoscowTimeShift = 3;

    void Awake( )
    {
        DateTime moscowTime = GetMoscowTime();

        _numericClockView.Set(
            hour: moscowTime.Hour.ToString(),
            minute: moscowTime.Minute.ToString(),
            second: moscowTime.Second.ToString()
        );
    }

    [Button]
    DateTime GetMoscowTime( )
    {
        DateTime utcDateTime = _yandex.GetCurrentUtcDateTime();

        DateTime moscowTime = utcDateTime.AddHours( MoscowTimeShift );

        Debug.Log( $"<color=cyan> {moscowTime} </color>" );
        Debug.Log( $"<color=cyan> {TimeZoneInfo.Local} </color>" );
        return moscowTime;
    }

}
}