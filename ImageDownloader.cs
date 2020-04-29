using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ImageDownloader : MonoBehaviour
{
    private IEnumerator DownloadImage(string MediaUrl)
    {
        Texture2D texture = null;
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
        }
    }
}
