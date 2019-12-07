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
					SlotMiddle.GetComponent<CheckSlotMiddle> ().slotmiddle [SlotMiddle.GetComponent<CheckSlotMiddle> ().NbrCardMiddle].GetComponent<ApplyCardMiddle> ().attack= DragHandeler.itemBeingDragged.gameObject.GetComponent<clickCard> ().attack;
					SlotMiddle.GetComponent<CheckSlotMiddle> ().slotmiddle [SlotMiddle.GetComponent<CheckSlotMiddle> ().NbrCardMiddle].GetComponent<ApplyCardMiddle> ().objattack.GetComponent<Text> ().text = SlotMiddle.GetComponent<CheckSlotMiddle> ().slotmiddle [SlotMiddle.GetComponent<CheckSlotMiddle> ().NbrCardMiddle].GetComponent<ApplyCardMiddle> ().attack.ToString();
					SlotMiddle.GetComponent<CheckSlotMiddle> ().slotmiddle [SlotMiddle.GetComponent<CheckSlotMiddle> ().NbrCardMiddle].GetComponent<ApplyCardMiddle> ().price = DragHandeler.itemBeingDragged.gameObject.GetComponent<clickCard> ().price;
					SlotMiddle.GetComponent<CheckSlotMiddle> ().slotmiddle [SlotMiddle.GetComponent<CheckSlotMiddle> ().NbrCardMiddle].GetComponent<ApplyCardMiddle> ().objprice.GetComponent<Text> ().text = SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle> ().price.ToString();
					SlotMiddle.GetComponent<CheckSlotMiddle> ().slotmiddle [SlotMiddle.GetComponent<CheckSlotMiddle> ().NbrCardMiddle].GetComponent<ApplyCardMiddle> ().health = DragHandeler.itemBeingDragged.gameObject.GetComponent<clickCard> ().health;
                    SlotMiddle.GetComponent<CheckSlotMiddle> ().slotmiddle [SlotMiddle.GetComponent<CheckSlotMiddle> ().NbrCardMiddle].GetComponent<ApplyCardMiddle> ().objhealth.GetComponent<Text> ().text = SlotMiddle.GetComponent<CheckSlotMiddle>().slotmiddle[SlotMiddle.GetComponent<CheckSlotMiddle>().NbrCardMiddle].GetComponent<ApplyCardMiddle> ().health.ToString();

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
