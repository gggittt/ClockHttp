﻿using System;
using Newtonsoft.Json;
using UnityEngine;

namespace _Project.Core.YandexTimeRequest
{
public class YandexTimeParser : MonoBehaviour
{
    public DateTime GetUtcTime( string jsonString )
    {
        YandexJsonDateTime json = JsonConvert.DeserializeObject<YandexJsonDateTime>( jsonString );

        DateTimeOffset offset = DateTimeOffset.FromUnixTimeMilliseconds( json.Time );

        DateTime utcDateTime = offset.DateTime;

        return utcDateTime;
    }

    [System.Serializable]
    public class YandexJsonDateTime
    {
        public long Time;
        public object Clocks; //dummy for Yandex response mapping
    }
}
}