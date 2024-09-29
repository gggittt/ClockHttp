﻿using TMPro;
using UnityEngine;

namespace _Project.Core
{
public class NumericClockView : MonoBehaviour
{
    [SerializeField] TMP_Text _hour;
    [SerializeField] TMP_Text _minute;
    [SerializeField] TMP_Text _second;

    public void Set( string hour, string minute, string second )
    {
        _hour.text = hour;
        _minute.text = minute;
        _second.text = second;
    }
}
}