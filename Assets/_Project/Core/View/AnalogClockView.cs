using UnityEngine;

namespace _Project.Core
{
public class AnalogClockView : MonoBehaviour
{
    [SerializeField] Transform _hoursPivot;
    [SerializeField] Transform _minutesPivot;
    [SerializeField] Transform _secondsPivot;

    const int ClockwiseCoefficient = - 1;
    const int OnlyHalfHoursOnDialClockCoefficient = 2;

    const int HoursInAnalogDial = 12;
    const float HoursToDegrees = ClockwiseCoefficient * 360f / HoursInAnalogDial;

    const int MinutesInHours = 60;
    const float MinutesToDegrees = ClockwiseCoefficient * 360f / MinutesInHours;

    const int SecondsInMinute = 60;
    const float SecondsToDegrees = ClockwiseCoefficient * 360f / SecondsInMinute;

    public void Set( int hour, int minute, int second )
    {
        int additionalHourShift = minute % MinutesInHours * ClockwiseCoefficient / OnlyHalfHoursOnDialClockCoefficient;
        int hoursInDialFormat = hour % HoursInAnalogDial ;


        float hoursDegrees = ( HoursToDegrees * hoursInDialFormat ) + additionalHourShift;

        _hoursPivot.localRotation = Quaternion.Euler( 0f, 0f, hoursDegrees );
        _minutesPivot.localRotation = Quaternion.Euler( 0f, 0f, MinutesToDegrees * minute );
        _secondsPivot.localRotation = Quaternion.Euler( 0f, 0f, SecondsToDegrees * second );
    }
}
}