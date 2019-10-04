using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class NbrCardsManager : MonoBehaviour {

	public int NbrCard = 0;
	public GameObject[] Cards;
	public List<Cartes> mescartes = new List<Cartes>();
	public float speedDragCards = 5.0F;
	public float speedMoveCards = 5.0F;
	public float speedRotateCards = 20.0F;
	public bool cardClicked = false;
	public bool cardView = false;
	public int IDcardView;
	public bool StartDraw = false;
	public bool StartDrag = false;
	public GameObject StartDistrib;

	public GameObject[] slot;

	public GameObject monnaies;
	public GameObject ErrorMiddleMsg;

	public AudioClip soundDrag;
	private Vector3 posdefaultdraw = new Vector3 (0, -570, 0);
	private int IDcardClicked;
	private int NumberCardsHandMax = 8; //MAX 7 /!\IMPORTANT/!\

	void Start () {
		//START DRAG CARD GAME
		startDistrib ();
	}

	//START DRAG CARD GAME
	void startDistrib(){
		//START POSITION THE CARD GAME OF ANIMATION. POSITION DRAG TO HAND
		StartDistrib.SetActive (true);
		StartDraw = true;
	}

	// Update is called once per frame
	void Update () {

		//START DRAG CARD GAME
		if (StartDraw) {
			if (NbrCard <= NumberCardsHandMax-1) {
				StartDistrib.transform.localPosition = Vector3.Lerp (StartDistrib.transform.localPosition, posdefaultdraw, Time.deltaTime * speedDragCards);
				if (StartDistrib.transform.localPosition.y <= -555) {
						Cartes cart = new Cartes ();
						cart.cards = Cards [NbrCard];
						cart.cardId = NbrCard;
						cart.active = true;
						mescartes.Add (cart);
						Cards[NbrCard].SetActive (true);
						NbrCard++;
					GetComponent<AudioSource> ().PlayOneShot (soundDrag);
					StartDistrib.transform.localPosition = new Vector3 (730, -400, 0);
				}
			} else {
				StartDistrib.SetActive (false);
				StartDraw = false;
			}
		}

		//POSITION CARDS GAMES IN HAND IN FUNCTION THE NUMBER OF CARDS GAMES AND IF DRAG CARDS GAMES IS OFF
		if (!StartDrag) {
			//START TOLLTIP HAND CARD
			if (cardView) {
				Cards [IDcardView].transform.localPosition = Vector3.Lerp (Cards [IDcardView].transform.localPosition, new Vector3 (Cards [IDcardView].transform.localPosition.x - 50, 150, 0), Time.deltaTime * speedMoveCards);
				Cards [IDcardView].transform.eulerAngles = new Vector3 (0, 0, 0);
				Cards [IDcardView].transform.localScale = Vector3.Lerp (Cards [IDcardView].transform.localScale, new Vector3 (1.2f, 1.2f, 1.2f), Time.deltaTime * speedMoveCards);
			}

			if (NbrCard == 0 && mescartes.Count > 1) {
                mescartes [8].cards.gameObject.SetActive(false);
                mescartes [7].cards.gameObject.SetActive (false);
				mescartes [6].cards.gameObject.SetActive (false);
				mescartes [5].cards.gameObject.SetActive (false);
				mescartes [4].cards.gameObject.SetActive (false);
				mescartes [3].cards.gameObject.SetActive (false);
				mescartes [2].cards.gameObject.SetActive (false);
				mescartes [1].cards.gameObject.SetActive (false);
				mescartes [0].cards.gameObject.SetActive (false);
			} else {
                //IF 08 CARDS IN DECK

                if (NbrCard == 9)
                {
                    mescartes[8].cards.transform.localPosition = Vector3.Lerp(mescartes[7].cards.transform.localPosition, new Vector3(270, -15, 0), Time.deltaTime * speedMoveCards);
                    mescartes[8].cards.transform.localRotation = Quaternion.RotateTowards(mescartes[7].cards.transform.rotation, Quaternion.Euler(0, 0, -25), Time.deltaTime * speedRotateCards);

                    mescartes[7].cards.transform.localPosition = Vector3.Lerp(mescartes[7].cards.transform.localPosition, new Vector3(210, -10, 0), Time.deltaTime * speedMoveCards);
                    mescartes[7].cards.transform.localRotation = Quaternion.RotateTowards(mescartes[7].cards.transform.rotation, Quaternion.Euler(0, 0, -20), Time.deltaTime * speedRotateCards);

                    mescartes[6].cards.transform.localPosition = Vector3.Lerp(mescartes[6].cards.transform.localPosition, new Vector3(150, 5, 0), Time.deltaTime * speedMoveCards);
                    mescartes[6].cards.transform.localRotation = Quaternion.RotateTowards(mescartes[6].cards.transform.rotation, Quaternion.Euler(0, 0, -15), Time.deltaTime * speedRotateCards);

                    mescartes[5].cards.transform.localPosition = Vector3.Lerp(mescartes[5].cards.transform.localPosition, new Vector3(90, 15, 0), Time.deltaTime * speedMoveCards);
                    mescartes[5].cards.transform.localRotation = Quaternion.RotateTowards(mescartes[5].cards.transform.rotation, Quaternion.Euler(0, 0, -10), Time.deltaTime * speedRotateCards);

                    mescartes[4].cards.transform.localPosition = Vector3.Lerp(mescartes[4].cards.transform.localPosition, new Vector3(30, 20, 0), Time.deltaTime * speedMoveCards);
                    mescartes[4].cards.transform.localRotation = Quaternion.RotateTowards(mescartes[4].cards.transform.rotation, Quaternion.Euler(0, 0, -5), Time.deltaTime * speedRotateCards);

                    mescartes[3].cards.transform.localPosition = Vector3.Lerp(mescartes[3].cards.transform.localPosition, new Vector3(-30, 20, 0), Time.deltaTime * speedMoveCards);
                    mescartes[3].cards.transform.localRotation = Quaternion.RotateTowards(mescartes[3].cards.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * speedRotateCards);

                    mescartes[2].cards.transform.localPosition = Vector3.Lerp(mescartes[2].cards.transform.localPosition, new Vector3(-90, 15, 0), Time.deltaTime * speedMoveCards);
                    mescartes[2].cards.transform.localRotation = Quaternion.RotateTowards(mescartes[2].cards.transform.rotation, Quaternion.Euler(0, 0, 5), Time.deltaTime * speedRotateCards);

                    mescartes[1].cards.transform.localPosition = Vector3.Lerp(mescartes[1].cards.transform.localPosition, new Vector3(-150, 5, 0), Time.deltaTime * speedMoveCards);
                    mescartes[1].cards.transform.localRotation = Quaternion.RotateTowards(mescartes[1].cards.transform.rotation, Quaternion.Euler(0, 0, 10), Time.deltaTime * speedRotateCards);

                    mescartes[0].cards.transform.localPosition = Vector3.Lerp(mescartes[0].cards.transform.localPosition, new Vector3(-210, -10, 0), Time.deltaTime * speedMoveCards);
                    mescartes[0].cards.transform.localRotation = Quaternion.RotateTowards(mescartes[0].cards.transform.rotation, Quaternion.Euler(0, 0, 20), Time.deltaTime * speedRotateCards);

                    //IF 07 CARDS IN DECK
                } else if (NbrCard == 8) {
				
					mescartes [7].cards.transform.localPosition = Vector3.Lerp (mescartes [7].cards.transform.localPosition, new Vector3 (210, -10, 0), Time.deltaTime * speedMoveCards);
					mescartes [7].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [7].cards.transform.rotation, Quaternion.Euler (0, 0, -20), Time.deltaTime * speedRotateCards);

					mescartes [6].cards.transform.localPosition = Vector3.Lerp (mescartes [6].cards.transform.localPosition, new Vector3 (150, 5, 0), Time.deltaTime * speedMoveCards);
					mescartes [6].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [6].cards.transform.rotation, Quaternion.Euler (0, 0, -15), Time.deltaTime * speedRotateCards);

					mescartes [5].cards.transform.localPosition = Vector3.Lerp (mescartes [5].cards.transform.localPosition, new Vector3 (90, 15, 0), Time.deltaTime * speedMoveCards);
					mescartes [5].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [5].cards.transform.rotation, Quaternion.Euler (0, 0, -10), Time.deltaTime * speedRotateCards);

					mescartes [4].cards.transform.localPosition = Vector3.Lerp (mescartes [4].cards.transform.localPosition, new Vector3 (30, 20, 0), Time.deltaTime * speedMoveCards);
					mescartes [4].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [4].cards.transform.rotation, Quaternion.Euler (0, 0, -5), Time.deltaTime * speedRotateCards);

					mescartes [3].cards.transform.localPosition = Vector3.Lerp (mescartes [3].cards.transform.localPosition, new Vector3 (-30, 20, 0), Time.deltaTime * speedMoveCards);
					mescartes [3].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [3].cards.transform.rotation, Quaternion.Euler (0, 0, 0), Time.deltaTime * speedRotateCards);

					mescartes [2].cards.transform.localPosition = Vector3.Lerp (mescartes [2].cards.transform.localPosition, new Vector3 (-90, 15, 0), Time.deltaTime * speedMoveCards);
					mescartes [2].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [2].cards.transform.rotation, Quaternion.Euler (0, 0, 5), Time.deltaTime * speedRotateCards);

					mescartes [1].cards.transform.localPosition = Vector3.Lerp (mescartes [1].cards.transform.localPosition, new Vector3 (-150, 5, 0), Time.deltaTime * speedMoveCards);
					mescartes [1].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [1].cards.transform.rotation, Quaternion.Euler (0, 0, 10), Time.deltaTime * speedRotateCards);

					mescartes [0].cards.transform.localPosition = Vector3.Lerp (mescartes [0].cards.transform.localPosition, new Vector3 (-210, -10, 0), Time.deltaTime * speedMoveCards);
					mescartes [0].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [0].cards.transform.rotation, Quaternion.Euler (0, 0, 20), Time.deltaTime * speedRotateCards);

					//IF 07 CARDS IN DECK
				} else if (NbrCard == 7) {

					mescartes [6].cards.transform.localPosition = Vector3.Lerp (mescartes [6].cards.transform.localPosition, new Vector3 (180, 0, 0), Time.deltaTime * speedMoveCards);
					mescartes [6].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [6].cards.transform.rotation, Quaternion.Euler (0, 0, -15), Time.deltaTime * speedRotateCards);

					mescartes [5].cards.transform.localPosition = Vector3.Lerp (mescartes [5].cards.transform.localPosition, new Vector3 (120, 15, 0), Time.deltaTime * speedMoveCards);
					mescartes [5].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [5].cards.transform.rotation, Quaternion.Euler (0, 0, -10), Time.deltaTime * speedRotateCards);

					mescartes [4].cards.transform.localPosition = Vector3.Lerp (mescartes [4].cards.transform.localPosition, new Vector3 (60, 25, 0), Time.deltaTime * speedMoveCards);
					mescartes [4].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [4].cards.transform.rotation, Quaternion.Euler (0, 0, -5), Time.deltaTime * speedRotateCards);

					mescartes [3].cards.transform.localPosition = Vector3.Lerp (mescartes [3].cards.transform.localPosition, new Vector3 (0, 30, 0), Time.deltaTime * speedMoveCards);
					mescartes [3].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [3].cards.transform.rotation, Quaternion.Euler (0, 0, 0), Time.deltaTime * speedRotateCards);

					mescartes [2].cards.transform.localPosition = Vector3.Lerp (mescartes [2].cards.transform.localPosition, new Vector3 (-60, 25, 0), Time.deltaTime * speedMoveCards);
					mescartes [2].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [2].cards.transform.rotation, Quaternion.Euler (0, 0, 5), Time.deltaTime * speedRotateCards);

					mescartes [1].cards.transform.localPosition = Vector3.Lerp (mescartes [1].cards.transform.localPosition, new Vector3 (-120, 15, 0), Time.deltaTime * speedMoveCards);
					mescartes [1].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [1].cards.transform.rotation, Quaternion.Euler (0, 0, 10), Time.deltaTime * speedRotateCards);

					mescartes [0].cards.transform.localPosition = Vector3.Lerp (mescartes [0].cards.transform.localPosition, new Vector3 (-180, 0, 0), Time.deltaTime * speedMoveCards);
					mescartes [0].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [0].cards.transform.rotation, Quaternion.Euler (0, 0, 15), Time.deltaTime * speedRotateCards);

					//IF 06 CARDS IN DECK
				} else if (NbrCard == 6) {
				
					mescartes [5].cards.transform.localPosition = Vector3.Lerp (mescartes [5].cards.transform.localPosition, new Vector3 (150, 5, 0), Time.deltaTime * speedMoveCards);
					mescartes [5].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [5].cards.transform.rotation, Quaternion.Euler (0, 0, -10), Time.deltaTime * speedRotateCards);

					mescartes [4].cards.transform.localPosition = Vector3.Lerp (mescartes [4].cards.transform.localPosition, new Vector3 (90, 15, 0), Time.deltaTime * speedMoveCards);
					mescartes [4].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [4].cards.transform.rotation, Quaternion.Euler (0, 0, -5), Time.deltaTime * speedRotateCards);

					mescartes [3].cards.transform.localPosition = Vector3.Lerp (mescartes [3].cards.transform.localPosition, new Vector3 (30, 20, 0), Time.deltaTime * speedMoveCards);
					mescartes [3].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [3].cards.transform.rotation, Quaternion.Euler (0, 0, -2), Time.deltaTime * speedRotateCards);

					mescartes [2].cards.transform.localPosition = Vector3.Lerp (mescartes [2].cards.transform.localPosition, new Vector3 (-30, 20, 0), Time.deltaTime * speedMoveCards);
					mescartes [2].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [2].cards.transform.rotation, Quaternion.Euler (0, 0, 2), Time.deltaTime * speedRotateCards);

					mescartes [1].cards.transform.localPosition = Vector3.Lerp (mescartes [1].cards.transform.localPosition, new Vector3 (-90, 15, 0), Time.deltaTime * speedMoveCards);
					mescartes [1].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [1].cards.transform.rotation, Quaternion.Euler (0, 0, 5), Time.deltaTime * speedRotateCards);

					mescartes [0].cards.transform.localPosition = Vector3.Lerp (mescartes [0].cards.transform.localPosition, new Vector3 (-150, 5, 0), Time.deltaTime * speedMoveCards);
					mescartes [0].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [0].cards.transform.rotation, Quaternion.Euler (0, 0, 10), Time.deltaTime * speedRotateCards);

					//IF 05 CARDS IN DECK
				} else if (NbrCard == 5) {

					mescartes [4].cards.transform.localPosition = Vector3.Lerp (mescartes [4].cards.transform.localPosition, new Vector3 (140, 5, 0), Time.deltaTime * speedMoveCards);
					mescartes [4].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [4].cards.transform.rotation, Quaternion.Euler (0, 0, -15), Time.deltaTime * speedRotateCards);

					mescartes [3].cards.transform.localPosition = Vector3.Lerp (mescartes [3].cards.transform.localPosition, new Vector3 (70, 20, 0), Time.deltaTime * speedMoveCards);
					mescartes [3].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [3].cards.transform.rotation, Quaternion.Euler (0, 0, -5), Time.deltaTime * speedRotateCards);

					mescartes [2].cards.transform.localPosition = Vector3.Lerp (mescartes [2].cards.transform.localPosition, new Vector3 (0, 25, 0), Time.deltaTime * speedMoveCards);
					mescartes [2].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [2].cards.transform.rotation, Quaternion.Euler (0, 0, 0), Time.deltaTime * speedRotateCards);

					mescartes [1].cards.transform.localPosition = Vector3.Lerp (mescartes [1].cards.transform.localPosition, new Vector3 (-70, 20, 0), Time.deltaTime * speedMoveCards);
					mescartes [1].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [1].cards.transform.rotation, Quaternion.Euler (0, 0, 5), Time.deltaTime * speedRotateCards);

					mescartes [0].cards.transform.localPosition = Vector3.Lerp (mescartes [0].cards.transform.localPosition, new Vector3 (-140, 5, 0), Time.deltaTime * speedMoveCards);
					mescartes [0].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [0].cards.transform.rotation, Quaternion.Euler (0, 0, 15), Time.deltaTime * speedRotateCards);

					//IF 04 CARDS IN DECK
				} else if (NbrCard == 4) {
				
					mescartes [3].cards.transform.localPosition = Vector3.Lerp (mescartes [3].cards.transform.localPosition, new Vector3 (100, 10, 0), Time.deltaTime * speedMoveCards);
					mescartes [3].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [3].cards.transform.rotation, Quaternion.Euler (0, 0, -15), Time.deltaTime * speedRotateCards);

					mescartes [2].cards.transform.localPosition = Vector3.Lerp (mescartes [2].cards.transform.localPosition, new Vector3 (30, 25, 0), Time.deltaTime * speedMoveCards);
					mescartes [2].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [2].cards.transform.rotation, Quaternion.Euler (0, 0, -5), Time.deltaTime * speedRotateCards);

					mescartes [1].cards.transform.localPosition = Vector3.Lerp (mescartes [1].cards.transform.localPosition, new Vector3 (-30, 25, 0), Time.deltaTime * speedMoveCards);
					mescartes [1].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [1].cards.transform.rotation, Quaternion.Euler (0, 0, 5), Time.deltaTime * speedRotateCards);

					mescartes [0].cards.transform.localPosition = Vector3.Lerp (mescartes [0].cards.transform.localPosition, new Vector3 (-100, 10, 0), Time.deltaTime * speedMoveCards);
					mescartes [0].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [0].cards.transform.rotation, Quaternion.Euler (0, 0, 15), Time.deltaTime * speedRotateCards);

					//IF 03 CARDS IN DECK
				} else if (NbrCard == 3) {
				
					mescartes [2].cards.transform.localPosition = Vector3.Lerp (mescartes [2].cards.transform.localPosition, new Vector3 (70, 20, 0), Time.deltaTime * speedMoveCards);
					mescartes [2].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [2].cards.transform.rotation, Quaternion.Euler (0, 0, -5), Time.deltaTime * speedRotateCards);

					mescartes [1].cards.transform.localPosition = Vector3.Lerp (mescartes [1].cards.transform.localPosition, new Vector3 (0, 25, 0), Time.deltaTime * speedMoveCards);
					mescartes [1].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [1].cards.transform.rotation, Quaternion.Euler (0, 0, 0), Time.deltaTime * speedRotateCards);

					mescartes [0].cards.transform.localPosition = Vector3.Lerp (mescartes [0].cards.transform.localPosition, new Vector3 (-70, 20, 0), Time.deltaTime * speedMoveCards);
					mescartes [0].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [0].cards.transform.rotation, Quaternion.Euler (0, 0, 5), Time.deltaTime * speedRotateCards);

					//IF 02 CARDS IN DECK
				} else if (NbrCard == 2) {
				
					mescartes [1].cards.transform.localPosition = Vector3.Lerp (mescartes [1].cards.transform.localPosition, new Vector3 (30, 25, 0), Time.deltaTime * speedMoveCards);
					mescartes [1].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [1].cards.transform.rotation, Quaternion.Euler (0, 0, -5), Time.deltaTime * speedRotateCards);

					mescartes [0].cards.transform.localPosition = Vector3.Lerp (mescartes [0].cards.transform.localPosition, new Vector3 (-30, 25, 0), Time.deltaTime * speedMoveCards);
					mescartes [0].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [0].cards.transform.rotation, Quaternion.Euler (0, 0, 5), Time.deltaTime * speedRotateCards);

					//IF 01 CARDS IN DECK
				} else if (NbrCard == 1) {

					mescartes [0].cards.transform.localPosition = Vector3.Lerp (mescartes [0].cards.transform.localPosition, new Vector3 (0, 25, 0), Time.deltaTime * speedMoveCards);
					mescartes [0].cards.transform.localRotation = Quaternion.RotateTowards (mescartes [0].cards.transform.rotation, Quaternion.Euler (0, 0, 0), Time.deltaTime * speedRotateCards);
				}
			}
		}
	}

	//APPLY CARD GAME MIDDLE AFTER DRAG
	public void ClickChangeCard(int carteid){
        if (!StartDraw) {
			foreach (Cartes cart in mescartes.ToArray()) {
				if (cart.cardId == carteid) {
					IDcardClicked = carteid;
					mescartes.Remove (cart);
					NbrCard -= 1;
				}
			}
		}
	}

	//STARTCOROUTINE TOOLTIP CARD GAME MOUSEOVER
	public void viewCard(){
		if (!StartDrag) {
			StartCoroutine ("viewcard");
		}
	}

	//OFF TOOLTIP CARD GAME MOUSEOVER
	public void viewCardOff(){
		StopCoroutine ("viewcard");
		Cards [IDcardView].transform.localScale = new Vector3 (1.2f, 1.2f, 1.2f);
		cardView = false;
	}

	//POSTER MIDDLE SLOT DURING DRAG CARDS GAME
	public void CheckSlot(){
		foreach (GameObject slotimg in slot) {
			slotimg.GetComponent<Image> ().enabled = true;
		}
	}

	//CHECK MIDDLE SLOT IS EMPTY OR NOT AND ON OR OFF
	public void CheckSlot2(){
		foreach (GameObject slotimg in slot) {
			slotimg.GetComponent<Image> ().enabled = false;
		}
	}

	//IENUMERATOR THE FUNCTION LINE 239
	IEnumerator viewcard(){
		yield return new WaitForSeconds (1f);
		cardView = true;
		StopCoroutine ("viewcard");
	}
}

//ARRAY CARDS GAMES
[System.Serializable]
public class Cartes {
	public GameObject cards;
	public int cardId;
	public bool active = false;
}