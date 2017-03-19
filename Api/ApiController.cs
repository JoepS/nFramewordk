using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace nFramework.Api{

	public static class ApiController {
		static string _baseUrl;
		static List<string> _urls;

		public static IEnumerator startRequest(string url, Data data, Action<string> succes, Action<string> error)
		{
			WWWForm form = new WWWForm();
            WWW www;
            if (data != null)
            {
                List<string> keys = data.getKeys();
                List<string> values = data.getValues();
                for (int i = 0; i < keys.Count; i++)
                {
                    form.AddField(keys[i], values[i]);
                }
                www = new WWW(_baseUrl + url, form);
            }
            else
            {
                www = new WWW(_baseUrl + url);
            }

			yield return www;
            if (string.IsNullOrEmpty(www.error))
            {
                succes.Invoke(www.text);
            }
            else {
                error.Invoke(www.error);
            }
		}

        public static void setBaseUrl(string newBaseUrl)
        {
            _baseUrl = newBaseUrl;
        }
	}
}
