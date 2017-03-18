using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class ApiController {
    static string _baseUrl;
    static List<string> _urls;

    public static IEnumerator startRequest(string url, Data data, Action<string> succes, Action<string> error)
    {
        WWWForm form = new WWWForm();
        List<string> keys = data.getKeys();
        List<string> values = data.getValues();
        for (int i = 0; i < keys.Count; i++)
        {
            form.AddField(keys[i], values[i]);
        }

        WWW www = new WWW(_baseUrl, form);

        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            succes.Invoke(www.text);
        }
        error.Invoke(www.error);
    }
}
