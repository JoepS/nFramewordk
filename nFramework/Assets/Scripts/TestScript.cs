using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nFrameWork.WWWControls;

public class TestScript : MonoBehaviour {

    WWWController _wwwController;

    void Start()
    {
        WWWController.BaseUrl = "http://www.joepsijtsma.com/api/";

        _wwwController = this.gameObject.AddComponent<WWWController>();
        _wwwController.GetRequest("ballrollerlevels", "test");

        StartCoroutine(WaitForResponse());
    }

    IEnumerator WaitForResponse()
    {
        string response = _wwwController.GetResponse("test");
        while(response == null)
        {
            yield return new WaitForSeconds(1);
            response = _wwwController.GetResponse("test");
        }

        Debug.Log(response);
    }

}
