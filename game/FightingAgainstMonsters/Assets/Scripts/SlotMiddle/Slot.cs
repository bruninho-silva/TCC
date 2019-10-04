using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {

	public bool isUse = false;
	public GameObject SlotMiddle;
	public AudioClip error;

	public GameObject item {
		get {
			if(transform.childCount>0){
				return transform.GetChild (0).gameObject;
			}
			return null;
		}
	}

	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData)
	{
		if(!item){
			if (!isUse) {
				//REDUC GOLDS IF TRUE
				if (SlotMiddle.GetComponent<CheckSlotMiddle> ().DeckManager.GetComponent<NbrCardsManager> ().monnaies.GetComponent<Monnaies> ().reduc (DragHandeler.itemBeingDragged.gameObject.GetComponent<clickCard> ().price)) {

					SlotMiddle.GetComponent<CheckSlotMiddle> ().playsoundPose ();
					DragHandeler.itemBeingDragged.gameObject.GetComponent<clickCard> ().deck.GetComponent<NbrCardsManager> ().CheckSlot2 ();
					DragHandeler.itemBeingDragged.gameObject.GetComponent<clickCard> ().deck.GetComponent<NbrCardsManager> ().StartDrag = false;

					//DISABLE CARD IN HAND
					DragHandeler.itemBeingDragged.gameObject.SetActive (false);
					DragHandeler.itemBeingDragged.gameObject.GetComponent<clickCard> ().ApplyCard ();

					SlotMiddle.GetComponent<CheckSlotMiddle> ().PoseCard = DragHandeler.itemBeingDragged.transform.localPosition;

					//STOP IN CHECKSLOTMIDDLE.CS POSITION CARDS MIDDLE
					SlotMiddle.GetComponent<CheckSlotMiddle> ().ApplyMiddleCards = false;

					//SEND CARDS IMAGE TO SLOT MIDDLE
					SlotMiddle.GetComponent<CheckSlotMiddle> ().slotmiddle [SlotMiddle.GetComponent<CheckSlotMiddle> ().NbrCardMiddle].GetComponent<Image> ().sprite = DragHandeler.itemBeingDragged.gameObject.GetComponent<Image> ().sprite;

					//SEND STATS AND IMAGES PRICE, ATTACK AND HEALTH TO SLOT MIDDLE
					SlotMiddle.GetComponent<CheckSlotMiddle> ().slotmiddle [SlotMiddle.GetComponent<CheckSlotMiddle> ().NbrCardMiddle].GetComponent<ApplyCardMiddle> ().attack = DragHandeler.itemBeingDragged.gameObject.GetComponent<clickCard> ().attack;
					SlotMiddle.GetComponent<CheckSlotMiddle> ().slotmiddle [SlotMiddle.GetComponent<CheckSlotMiddle> ().NbrCardMiddle].GetComponent<ApplyCardMiddle> ().objattack.GetComponent<Image> ().sprite = SlotMiddle.GetComponent<CheckSlotMiddle> ().slotmiddle [SlotMiddle.GetComponent<CheckSlotMiddle> ().NbrCardMiddle].GetComponent<ApplyCardMiddle> ().imgAttack [SlotMiddle.GetComponent<CheckSlotMiddle> ().slotmiddle [SlotMiddle.GetComponent<CheckSlotMiddle> ().NbrCardMiddle].GetComponent<ApplyCardMiddle> ().attack];
					SlotMiddle.GetComponent<CheckSlotMiddle> ().slotmiddle [SlotMiddle.GetComponent<CheckSlotMiddle> ().NbrCardMiddle].GetComponent<ApplyCardMiddle> ().price = DragHandeler.itemBeingDragged.gameObject.GetComponent<clickCard> ().price;
					SlotMiddle.GetComponent<CheckSlotMiddle> ().slotmiddle [SlotMiddle.GetComponent<CheckSlotMiddle> ().NbrCardMiddle].GetComponent<ApplyCardMiddle> ().objprice.GetComponent<Image> ().sprite = SlotMiddle.GetComponent<CheckSlotMiddle> ().slotmiddle [SlotMiddle.GetComponent<CheckSlotMiddle> ().NbrCardMiddle].GetComponent<ApplyCardMiddle> ().imgPrice [SlotMiddle.GetComponent<CheckSlotMiddle> ().slotmiddle [SlotMiddle.GetComponent<CheckSlotMiddle> ().NbrCardMiddle].GetComponent<ApplyCardMiddle> ().price];
					SlotMiddle.GetComponent<CheckSlotMiddle> ().slotmiddle [SlotMiddle.GetComponent<CheckSlotMiddle> ().NbrCardMiddle].GetComponent<ApplyCardMiddle> ().health = DragHandeler.itemBeingDragged.gameObject.GetComponent<clickCard> ().health;
					SlotMiddle.GetComponent<CheckSlotMiddle> ().slotmiddle [SlotMiddle.GetComponent<CheckSlotMiddle> ().NbrCardMiddle].GetComponent<ApplyCardMiddle> ().objhealth.GetComponent<Image> ().sprite = SlotMiddle.GetComponent<CheckSlotMiddle> ().slotmiddle [SlotMiddle.GetComponent<CheckSlotMiddle> ().NbrCardMiddle].GetComponent<ApplyCardMiddle> ().imgHealth [SlotMiddle.GetComponent<CheckSlotMiddle> ().slotmiddle [SlotMiddle.GetComponent<CheckSlotMiddle> ().NbrCardMiddle].GetComponent<ApplyCardMiddle> ().health];

                    SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().atributo1 = DragHandeler.itemBeingDragged.gameObject.GetComponent<clickCard>().atributo1;
                    SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().objatributo1.GetComponent<Image>().sprite = SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().imgatributo1[SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().atributo1];

                    SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().atributo2 = DragHandeler.itemBeingDragged.gameObject.GetComponent<clickCard>().atributo2;
                    SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().objatributo2.GetComponent<Image>().sprite = SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().imgatributo2[SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().atributo2];

                    SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().atributo3 = DragHandeler.itemBeingDragged.gameObject.GetComponent<clickCard>().atributo3;
                    SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().objatributo3.GetComponent<Image>().sprite = SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().imgatributo3[SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().atributo3];

                    SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().atributo4 = DragHandeler.itemBeingDragged.gameObject.GetComponent<clickCard>().atributo4;
                    SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().objatributo4.GetComponent<Image>().sprite = SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().imgatributo4[SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().atributo4];

                    SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().atributo5 = DragHandeler.itemBeingDragged.gameObject.GetComponent<clickCard>().atributo5;
                    SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().objatributo5.GetComponent<Image>().sprite = SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().imgatributo5[SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().atributo5];

                    SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().atributo6 = DragHandeler.itemBeingDragged.gameObject.GetComponent<clickCard>().atributo6;
                    SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().objatributo6.GetComponent<Image>().sprite = SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().imgatributo6[SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle>().atributo6];


                    //ADD +1 TO GLOBAL NUMBER CARDS PLAYED TO MIDDLE
                    SlotMiddle.GetComponent<CheckSlotMiddle> ().NbrCardMiddle += 1;
				} else {
					StopCoroutine ("finErrorMsg");
					SlotMiddle.GetComponent<CheckSlotMiddle> ().DeckManager.GetComponent<NbrCardsManager> ().ErrorMiddleMsg.GetComponent<Text> ().enabled = true;
					StartCoroutine ("finErrorMsg");
					GetComponent<AudioSource> ().PlayOneShot (error);
				}
			}
		}
	}
	#endregion

	IEnumerator finErrorMsg(){
		yield return new WaitForSeconds (2.5f);
		SlotMiddle.GetComponent<CheckSlotMiddle> ().DeckManager.GetComponent<NbrCardsManager> ().ErrorMiddleMsg.GetComponent<Text> ().enabled = false;
		StopCoroutine ("finErrorMsg");
	}
}
