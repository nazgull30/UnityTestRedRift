using System;
using UnityEngine;
using UnityEngine.Networking;

namespace UnityTestRedRift.Util
{
    public class TextureWWWLoader
    {
        public void Load(string url, Action<Texture> success)
        {
            var request = UnityWebRequestTexture.GetTexture(url);
            var op = request.SendWebRequest();
            op.completed += operation =>
            {
                if (request.isNetworkError || request.isHttpError)
                {
                    Debug.Log(request.error);   
                }
                else
                {
                    var texture = ((DownloadHandlerTexture) request.downloadHandler).texture;
                    success.Invoke(texture);
                }
            };
        }
    }
}