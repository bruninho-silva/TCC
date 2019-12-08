using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyperlink : MonoBehaviour
{

    public void moodleurl()
    {
        Application.OpenURL("http://blog.unicluster.com.br/");

    }

    public void devdoourl()
    {
        Application.OpenURL("http://www.devdoo.com");
    }

    public void uniprurl()
    {
        Application.OpenURL("https://www.unip.br/");
    }

   
}