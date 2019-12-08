using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyperlink : MonoBehaviour
{
    private readonly string urlunip = "https://www.unip.br";
    private readonly string urldevdoo = "http://www.devdoo.com";
    private readonly string urlmoodle = "http://blog.unicluster.com.br/";
    public string urloption;
    public void OpenLink()
    {
        var url = "";

        if (urloption == "unip")
        {
            url = urlunip;
        }
        else if (urloption == "devdoo")
        {
            url = urldevdoo;
        }
        else if (urloption == "moodle")
        {
            url = urlmoodle;
        }
        Application.OpenURL(url);
    }
}