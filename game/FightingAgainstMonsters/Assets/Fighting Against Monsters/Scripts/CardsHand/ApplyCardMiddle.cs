using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ApplyCardMiddle : MonoBehaviour {

   
    public int price;
	public int attack;
	public int health;

    public GameObject objprice;
	public GameObject objattack;
	public GameObject objhealth;

    
    public bool mePositionForDeadLeft = false;
    public bool mePositionForDeadRight = false;
    public AudioClip loss;


    void Start() {

        
       
        objprice.GetComponent<Text>().text = price.ToString();
        objattack.GetComponent<Text>().text = attack.ToString();
        objhealth.GetComponent<Text>().text = health.ToString();

    }

  

	void FixedUpdate() {

       
      
        
    }

    public void damage(int dmg)
    {
        health -= dmg;
        GetComponent<floatingDmg>().affiche(dmg.ToString());

        if (health <= 0)
        {
            objhealth.GetComponent<Text>().text = health.ToString();
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
            if (mePositionForDeadLeft)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.left * 90000);
            }
            else if (mePositionForDeadRight)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.right * 90000f);
                GetComponent<Rigidbody>().AddTorque(transform.up * 0f * 90000f);
            }
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<AudioSource>().PlayOneShot(loss);
            (this.tag) = "posed";

        }
        else
        {
            objhealth.GetComponent<Text>().text = health.ToString();
            
        }
    }
}
