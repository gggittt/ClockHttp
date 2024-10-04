using _Project.Extensions;
using TMPro;
using UnityEngine;

namespace _Project.Core.View
{
public class NumericClockView : MonoBehaviour
{
    [SerializeField] TMP_Text _hour;
    [SerializeField] TMP_Text _minute;
    [SerializeField] TMP_Text _second;

    public void Set( string hour, string minute, string second )
    {
        _hour.text = hour.AddZeroInFrontIfSingleDigit();
        _minute.text = minute.AddZeroInFrontIfSingleDigit();
        _second.text = second.AddZeroInFrontIfSingleDigit();
    }
}
}