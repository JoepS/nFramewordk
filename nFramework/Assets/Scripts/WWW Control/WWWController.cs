using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nFrameWork.WWWControls
{
    public class WWWController : MonoBehaviour
    {
        static string _baseUrl;
        public static string BaseUrl { set { _baseUrl = value; } }

        Dictionary<string, object> _responses = new Dictionary<string, object>();

        public void GetRequest(string url, string key)
        {
            StartCoroutine(Get(_baseUrl + url, key));
        }

        IEnumerator Get(string url, string key)
        {
            WWW www = new WWW(url);
            yield return www;
            if (www.error != null)
            {
                Debug.LogError(url + " gives error: " + www.error);
            }
            else
            {
                _responses.Add(key, www.text);
            }
        }

        public void PostRequest(string url, string key, string dataKey, string jsonData)
        {
            WWWForm form = new WWWForm();
            form.AddField(dataKey, jsonData);
        }

        IEnumerator Post(string url, WWWForm form)
        {
            WWW www = new WWW(url, form);
            yield return www;
            if(www.error != null)
            {
                Debug.LogError(url + " gives error: " + www.error);
            }
            else
            {
                Debug.Log("Succesfully uploaded " + form.data + " to " + url);
            }
        }

        public string GetResponse(string key)
        {
            object value;
            if(_responses.TryGetValue(key, out value))
            {
                return (string)value;
            }
            return null;
        }
    }
}
