using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Core
{
class YandexTimerProvider : MonoBehaviour, ITimerProvider
{
    [SerializeField] string _url = "https://yandex.com/time/sync.json";
    [SerializeField] UnityWebRequester _unityWebRequester;

    [Button]
    public DateTime GetCurrentDateTime( )
    {
        string result = _unityWebRequester.SendRequestTo( _url );

        Debug.Log( $"<color=cyan> {result} </color>" );
        return default;
    }
}
}