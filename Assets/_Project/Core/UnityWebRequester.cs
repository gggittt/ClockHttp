using System;
using System.Collections;
using Extensions.UnityTypes;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Networking;

namespace _Project.Core
{
public class UnityWebRequester : MonoBehaviour
{
    string _requestResult;

    public string SendRequestTo( string url )
    {
        Debug.Log( $"<color=cyan> {nameof( SendRequestTo )} </color>" );

        StartCoroutine( RequestToWebCoroutine( url, HandleAnswer ) );

        return _requestResult;
    }

    void HandleAnswer( string text )
    {
        _requestResult = text;
    }

    IEnumerator RequestToWebCoroutine( string url, Action<string> callback )
    {
        using (UnityWebRequest request = UnityWebRequest.Get( url ))
        {
            yield return request.SendWebRequest();

            if ( request.IsError() )
            {
                Debug.LogError( request.error );
            }
            else
            {
                callback( request.downloadHandler.text );
            }

        }

        yield return null;
    }

}
}