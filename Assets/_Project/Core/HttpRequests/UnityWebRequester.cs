using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Networking;

namespace _Project.Core.HttpRequests
{
public class UnityWebRequester : MonoBehaviour, IWebRequester
{
    [SerializeField] int _requestsAttemptAmount = 5;
    [SerializeField] float _pauseBetweenAttemptInSeconds = 0.5f;
    string _requestResult;
    WaitForSeconds _requestToWebCoroutine;

    void Awake( )
    {
        _requestToWebCoroutine = new WaitForSeconds( _pauseBetweenAttemptInSeconds );
    }

    [Button]
    public string SendRequestTo( string url )
    {
        StartCoroutine( RequestToWebCoroutine( url, HandleAnswer ) );

        Debug.Log( $"<color=cyan> {_requestResult} </color>" );

        return _requestResult;
    }

    void HandleAnswer( string text )
    {
        _requestResult = text;
    }

    IEnumerator RequestToWebCoroutine( string url, Action<string> successCallback )
    {
        int retryCount = 0;
        bool isSuccessful = false;

        while ( !isSuccessful && retryCount < _requestsAttemptAmount )
        {
            using UnityWebRequest request = UnityWebRequest.Get( url );
            yield return request.SendWebRequest();

            if ( request.result != UnityWebRequest.Result.Success )
            {
                retryCount++;
                Debug.LogError( $"Попытка подключения №{retryCount} Ошибка: {request.error}" );
            }
            else
            {
                successCallback( request.downloadHandler.text );
                isSuccessful = true;
            }

            yield return _requestToWebCoroutine;
        }

        // yield return null;
    }

}
}