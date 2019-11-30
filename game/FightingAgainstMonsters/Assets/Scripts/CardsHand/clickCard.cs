using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class clickCard : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler {

    public static List<clickCard> thiscard = new List<clickCard>();
    public int thisid;

    public GameObject deck;
	public int NombreCarte;
    public int idCarte;
	public int price;
	public int attack;
	public int health;

    public GameObject objprice;
	public GameObject objattack;
	public GameObject objhealth;

    public Sprite rImage;


    /*public AudioSource audio;*/
    public AudioClip click;


	// Use this for initialization
	void Start () {

         
        thiscard[0] = CardDataBase.cardList[thisid];
        

    }
	
	// Update is called once per frame
	void Update () {

		NombreCarte = deck.GetComponent<NbrCardsManager> ().NbrCard;
        //objprice.GetComponent<Text>().text = price.ToString();
        //objattack.GetComponent<Text>().text = attack.ToString();
        //objhealth.GetComponent<Text>().text = health.ToString();
    }

    public clickCard()
    {

    }

    public clickCard(int idCards, int goattack, int goprice, int gohealth, Sprite thisImage)
    {
        idCarte = idCards;
        attack = goattack;
        price = goprice;
        health = gohealth;
        rImage = thisImage;

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
