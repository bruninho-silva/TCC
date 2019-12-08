using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ApplyCardMiddle : MonoBehaviour {

   
    public int price;
	public int health;

    public int attack;
    public int velocidade;
    public int agilidade;
    public int inteligencia;

    public int attackdes;
    public int velocidadedes;
    public int agilidadedes;
    public int inteligenciades;

    public GameObject objprice;
	public GameObject objhealth;

    public GameObject objattack;
    public GameObject objvelocidade;
    public GameObject objagilidade;
    public GameObject objinteligencia;

    public GameObject objattackdes;
    public GameObject objvelocidadedes;
    public GameObject objagilidadedes;
    public GameObject objinteligenciades;


    public bool mePositionForDeadLeft = false;
    public bool mePositionForDeadRight = false;
    public AudioClip loss;


    void Start() {       

        objprice.GetComponent<Text>().text = price.ToString();
        objhealth.GetComponent<Text>().text = health.ToString();

        objattack.GetComponent<Text>().text = attack.ToString();
        objvelocidade.GetComponent<Text>().text = velocidade.ToString();
        objagilidade.GetComponent<Text>().text = agilidade.ToString();
        objinteligencia.GetComponent<Text>().text = inteligencia.ToString();

        objattackdes.GetComponent<Text>().text = attackdes.ToString();
        objvelocidadedes.GetComponent<Text>().text = velocidadedes.ToString();
        objagilidadedes.GetComponent<Text>().text = agilidadedes.ToString();
        objinteligenciades.GetComponent<Text>().text = inteligenciades.ToString();

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
