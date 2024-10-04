using System;
using Newtonsoft.Json;
using UnityEngine;

namespace _Project.Core.HttpRequests.YandexTimeRequest
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
    class YandexJsonDateTime
    {
        public long Time;
        public object Clocks; //dummy for Yandex response mapping
    }
}
}