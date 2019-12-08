using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOverUI : MonoBehaviour
{

    public GameObject panelS;
    public GameObject panelO;
   

    // Start is called before the first frame update

    public void startappear()
    {
        
        panelS.SetActive(true);
        

    }

    public void returnGame()
    {
        
        panelS.SetActive(false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
