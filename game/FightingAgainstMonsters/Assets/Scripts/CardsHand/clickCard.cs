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
    public int atributo1;
    public int atributo2;
    public int atributo3;
    public int atributo4;
    public int atributo5;
    public int atributo6;
    public Sprite[] imgPrice;
	public Sprite[] imgAttack;
	public Sprite[] imgHealth;
    public Sprite[] imgatributo1;
    public Sprite[] imgatributo2;
    public Sprite[] imgatributo3;
    public Sprite[] imgatributo4;
    public Sprite[] imgatributo5;
    public Sprite[] imgatributo6;
    public GameObject objprice;
	public GameObject objattack;
	public GameObject objhealth;
    public GameObject objatributo1;
    public GameObject objatributo2;
    public GameObject objatributo3;
    public GameObject objatributo4;
    public GameObject objatributo5;
    public GameObject objatributo6;
    public AudioSource audio;
	public AudioClip click;


	// Use this for initialization
	void Start () {
		objprice.GetComponent<Image> ().sprite = imgPrice [price];
		objattack.GetComponent<Image> ().sprite = imgAttack [attack];
		objhealth.GetComponent<Image> ().sprite = imgHealth [health];
        objatributo1.GetComponent<Image>().sprite = imgatributo1 [atributo1];
        objatributo2.GetComponent<Image>().sprite = imgatributo2 [atributo2];
        objatributo3.GetComponent<Image>().sprite = imgatributo3 [atributo3];
        objatributo4.GetComponent<Image>().sprite = imgatributo4 [atributo4];
        objatributo5.GetComponent<Image>().sprite = imgatributo5 [atributo5];
        objatributo6.GetComponent<Image>().sprite = imgatributo6 [atributo6];
    }
	
	// Update is called once per frame
	void Update () {
		NombreCarte = deck.GetComponent<NbrCardsManager> ().NbrCard;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		audio.PlayOneShot (click);
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
