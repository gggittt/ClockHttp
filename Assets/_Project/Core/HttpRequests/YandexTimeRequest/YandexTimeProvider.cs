using System;
using UnityEngine;

namespace _Project.Core.YandexTimeRequest
{
class YandexTimeProvider : MonoBehaviour, ITimeProvider
{
    [SerializeField] string _url = "https://yandex.com/time/sync.json";
    [SerializeField] UnityWebRequester _unityWebRequester;
    [SerializeField] YandexTimeParser _yandexTimeParser;

    [Sirenix.OdinInspector.Button]
    public DateTime GetCurrentUtcDateTime( )
    {
        string json = _unityWebRequester.SendRequestTo( _url );

        DateTime dateTime = _yandexTimeParser.GetUtcTime( json );

        return dateTime;
    }
}
}