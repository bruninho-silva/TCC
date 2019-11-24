using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorieManager : MonoBehaviour
{

    public GameObject any;
    public GameObject storie;
    public bool change = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void mudar()
    {
        if (!change)
        {

            
            Debug.Log("Mudou");

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
