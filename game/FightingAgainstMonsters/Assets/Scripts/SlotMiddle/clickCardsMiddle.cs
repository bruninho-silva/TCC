using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class clickCardsMiddle : MonoBehaviour , IPointerClickHandler {

    public CardsStatExample monster;
	public bool sleep = false;
	public bool chooseForAttack = false;
	public bool Attack = false;
	public bool Returnstartposition = false;
	public GameObject Arrow;
	public float speedAttack;
	public AudioClip Sweep;
	public GameObject deck;
	public GameObject enemy;
	public GameObject sleepObj;
    public bool mePositionForDeadLeft = false;
    public bool mePositionForDeadRight = false;

    public AudioClip loss;

    public Vector2 startposition;

	// Use this for initialization
	void Start () {
	
	}

	void Update(){
		//IF NO ATTACK
		if(!Attack){
			//IF NO SLEEPING
			if (!sleep) {
				//IF THE CARD CHOOSE FOR ATTACK
				if (chooseForAttack) {
					if (deck.GetComponent<CheckSlotMiddle> ().enemyObj) {
						if (Input.GetMouseButtonDown(0)) {
							enemy = deck.GetComponent<CheckSlotMiddle> ().enemyObj;
							enemy.GetComponent<overMouse> ().isAtacked = true;
							startposition = this.transform.localPosition;
							Attack = true;
							Arrow.GetComponent<Image> ().enabled = false;
							GetComponent<AudioSource> ().PlayOneShot (Sweep);
						}
					}
				}
			}
		//IF ATTACK
		}else if (Attack) {
			
			if (!enemy.GetComponent<overMouse> ().impact) { 
				this.transform.localPosition = Vector3.Lerp (this.transform.localPosition, enemy.transform.localPosition, Time.deltaTime * speedAttack);
			} else {
				Attack = false;
				sleepObj.GetComponent<Image> ().enabled = true;
				enemy.GetComponent<overMouse> ().isAtacked = false;
                enemy.GetComponent<CardsStatExample>().damage (GetComponent<ApplyCardMiddle>().attack);
				this.GetComponent<ApplyCardMiddle> ().damage (enemy.GetComponent<CardsStatExample> ().Attack);
                sleep = true;
				chooseForAttack = false;
				Returnstartposition = true;
				enemy.GetComponent<overMouse> ().impact = false;
                
			}
		}
		//RETRUN TO START POSITION
		if (Returnstartposition) {
			if (transform.localPosition.y > startposition.y) {
				StartCoroutine ("end");
				transform.localPosition = Vector3.Lerp (transform.localPosition, startposition, Time.deltaTime * speedAttack);
			}
		}
	}

	IEnumerator end(){
		yield return new WaitForSeconds (0.2f);
		Returnstartposition = false;
		enemy = null;
	}


	public void OnPointerClick(PointerEventData eventData){
		if (!sleep && !Attack) {
			Arrow.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y-50f, transform.localPosition.z);
			Arrow.GetComponent<Image> ().enabled = true;
			chooseForAttack = true;
		}
	}

}
