using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace _Project.Scripts.Model
{
    public static class ImageHandler
    { 
        public static IEnumerator SetupImageFromURL(Image image, string url) {
            var link = UnityWebRequestTexture.GetTexture(url);
            yield return link.SendWebRequest();

            if(link.isNetworkError || link.isHttpError) {
                Debug.Log(link.error);
            }
            else {
                var texture = ((DownloadHandlerTexture)link.downloadHandler).texture;
                image.overrideSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                    new Vector2(texture.width / 2, texture.height / 2));
            } 
        }
    }
}