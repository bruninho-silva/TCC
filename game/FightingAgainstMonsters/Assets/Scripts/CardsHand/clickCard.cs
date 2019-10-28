using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class clickCard : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler {

	public GameObject deck;
	public int NombreCarte;
    public int idCarte;
	public int price;
	public int attack;
	public int health;


   

    public GameObject objprice;
	public GameObject objattack;
	public GameObject objhealth;

    /*public AudioSource audio;*/
	public AudioClip click;


	// Use this for initialization
	void Start () {

		objprice.GetComponent<Text> ().text = price.ToString();
		objattack.GetComponent<Text> ().text = attack.ToString();
		objhealth.GetComponent<Text> ().text = health.ToString();

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
