using UnityEngine.Networking;

namespace _Project.Extensions.UnityTypes
{
public static class UnityWebRequestExtensions
{

    public static bool IsError( this UnityWebRequest request ) =>
        request.result == UnityWebRequest.Result.ConnectionError ||
        request.result == UnityWebRequest.Result.ProtocolError ||
        request.result == UnityWebRequest.Result.DataProcessingError;
        //or request.result != UnityWebRequest.Result.Success
}
}