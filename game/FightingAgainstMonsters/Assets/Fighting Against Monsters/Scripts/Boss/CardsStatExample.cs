﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CardsStatExample : MonoBehaviour {

    public int price;
    public int Attack;
    public int health;

    public GameObject cards;
    public GameObject objprice;
    public GameObject objattack;
    public GameObject objhealth;

    public bool boss = false;
    public bool mePositionForDeadLeft = false;
    public bool mePositionForDeadRight = false;
    public AudioClip loss;
    public AudioClip monsterHit;
    public string stage;
    public GameObject panel;
    public GameObject disch;
    public GameObject gameOver;
    public GameObject suc;
    public GameObject discp;
    public GameObject flm;
   


    // Use this for initialization
    void Start() {

        objattack.GetComponent<Text>().text = Attack.ToString();
        objhealth.GetComponent<Text>().text = health.ToString();

    }

    // Update is called once per frame
    void Update() {

    }

    public void damage(int dmg) {
        health -= dmg;
        GetComponent<floatingDmg>().affiche(dmg.ToString());

        if (health <= 0) {

            suc.SetActive(true);
            discp.SetActive(false);
            disch.SetActive(false);
            StartCoroutine("panelMode", (3f));
            StartCoroutine("bossDeath",(6f));
            objhealth.GetComponent<Text>().text = health.ToString();
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
            if (mePositionForDeadLeft) {
                GetComponent<Rigidbody>().AddForce(Vector3.left * 90000);
            } else if (mePositionForDeadRight) {
                GetComponent<Rigidbody>().AddForce(Vector3.right * 90000f);
                GetComponent<Rigidbody>().AddTorque(transform.up * 0f * 90000f);
            }
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<AudioSource>().PlayOneShot(loss);
            (this.tag) = "Enemy";
            disch.SetActive(false);




        } else {
            objhealth.GetComponent<Text>().text = health.ToString();
            GetComponent<AudioSource>().PlayOneShot(monsterHit);
           
            StartCoroutine("failmode", 2f);
        }
        StartCoroutine("overgame", 5f);
    }
    public IEnumerator bossDeath()
    {
        yield return new WaitForSeconds(3f);
        Application.LoadLevel(stage);
    }

    public IEnumerator panelMode()
    {
        yield return new WaitForSeconds(3f);
        panel.SetActive(true);
        
    }

    public IEnumerator failmode()
    {
        yield return new WaitForSeconds(2f);
        flm.SetActive(true);

    }

    public IEnumerator overgame()
    {
        yield return new WaitForSeconds(5f);
        gameOver.SetActive(true);

    }


}

