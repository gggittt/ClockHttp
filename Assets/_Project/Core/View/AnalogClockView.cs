using DG.Tweening;
using UnityEngine;

namespace _Project.Core.View
{
public class AnalogClockView : MonoBehaviour
{
    [SerializeField] Transform _hoursPivot;
    [SerializeField] Transform _minutesPivot;
    [SerializeField] Transform _secondsPivot;
    [SerializeField] bool _smoothHandMove; //could be shifted in runtime

    const int ClockwiseCoefficient = - 1;
    const int OnlyHalfHoursOnDialClockCoefficient = 2;

    const int HoursInAnalogDial = 12;
    const float DegreesInCircle = 360f;

    const float HoursToDegrees = ClockwiseCoefficient * DegreesInCircle / HoursInAnalogDial;

    const int MinutesInHours = 60;
    const float MinutesToDegrees = ClockwiseCoefficient * DegreesInCircle / MinutesInHours;

    const int SecondsInMinute = 60;
    const float SecondsToDegrees = ClockwiseCoefficient * DegreesInCircle / SecondsInMinute;

    public void Set( int hour, int minute, int second )
    {
        int hourShiftConsideringMinutesInHourProportion = minute % MinutesInHours * ClockwiseCoefficient / OnlyHalfHoursOnDialClockCoefficient;
        int hoursInDialFormat = hour % HoursInAnalogDial;

        float hoursDegrees = ( HoursToDegrees * hoursInDialFormat ) + hourShiftConsideringMinutesInHourProportion;

        if ( _smoothHandMove )
        {
            RotateHandsDoTweenSmooth( hoursDegrees, MinutesToDegrees * minute, SecondsToDegrees * second );
        }
        else
        {
            RotateHandsBuildIn( hoursDegrees, MinutesToDegrees * minute, SecondsToDegrees * second );
        }
    }

    void RotateHandsBuildIn( float hours, float minute, float second )
    {
        _hoursPivot.localRotation = Quaternion.Euler( 0f, 0f, hours );
        _minutesPivot.localRotation = Quaternion.Euler( 0f, 0f, minute );
        _secondsPivot.localRotation = Quaternion.Euler( 0f, 0f, second );
    }

    void RotateHandsDoTweenSmooth( float hours, float minutes, float second )
    {
        RotatePivot( _secondsPivot, second );
        RotatePivot( _minutesPivot, minutes );
        RotatePivot( _hoursPivot, hours );
    }

    void RotatePivot( Transform pivot, float amount )
    {
        pivot.DOLocalRotate( new Vector3( 0, 0, amount ), 1f ).SetEase( Ease.Linear );
    }

}
}