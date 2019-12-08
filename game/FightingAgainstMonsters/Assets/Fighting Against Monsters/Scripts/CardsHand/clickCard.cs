using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class clickCard : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler {

    public GameObject deck;
	public int NombreCarte;
    public int idCarte;

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


    /*public AudioSource audio;*/
    public AudioClip click;


	// Use this for initialization
	void Start () {

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
	
	// Update is called once per frame
	void Update () {

		NombreCarte = deck.GetComponent<NbrCardsManager> ().NbrCard;
      

    }

   

    public void OnPointerEnter(PointerEventData eventData)
	{
		/*audio.PlayOneShot (click);*/
		GetComponent<Outline> ().enabled = true;
		deck.GetComponent<NbrCardsManager> ().viewCard ();
		deck.GetComponent<NbrCardsManager> ().IDcardView = idCarte;
        //GetComponent<DragHandeler> ().enabled = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{

		GetComponent<Outline> ().enabled = false;
		deck.GetComponent<NbrCardsManager> ().viewCardOff ();
		deck.GetComponent<NbrCardsManager> ().IDcardView = idCarte;
        //GetComponent<DragHandeler> ().enabled = false;

    }

	public void ApplyCard(){

		deck.GetComponent<NbrCardsManager> ().ClickChangeCard (idCarte);

    }

    

}
