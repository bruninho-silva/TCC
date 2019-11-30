using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleStorie : MonoBehaviour
{

    public List<clickCard> Store = new List<clickCard>();
    public List<clickCard> container = new List<clickCard>();
    public int x;
    public int StoreSize;
    
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        StoreSize = 40; 

        for(int i = 0;  i<StoreSize; i++)
        {
            x = Random.Range(1, 5);
            
         

        }

    }

    public void Shuffle()
    {
        for(int i = 0; i < StoreSize; i++)
        {
            container[0] = Store[i];
            int randomIndex = Random.Range(i, StoreSize);
            Store[i] = Store[randomIndex];
            Store[randomIndex] = container[0];
        }
    }

  
    // Update is called once per frame
    void Update()
    {
        
    }
}
