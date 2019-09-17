using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	
	public static GameObject itemBeingDragged;
	public GameObject Deck;
	public AudioClip startdrag;

	Vector3 startPosition;
	Vector3 startScale;
	Quaternion startRotation;
	Transform startParent;

	void Start(){

	}

	void Update(){

	}

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		if (!Deck.GetComponent<NbrCardsManager> ().StartDraw) {
			itemBeingDragged = gameObject;
			startPosition = transform.localPosition;
			startRotation = transform.localRotation;
			startScale = transform.localScale;
			startParent = transform.parent;
			GetComponent<CanvasGroup> ().blocksRaycasts = false;
			GetComponent<AudioSource> ().PlayOneShot (startdrag);
		}
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		if (!Deck.GetComponent<NbrCardsManager> ().StartDraw) {
			Deck.GetComponent<NbrCardsManager> ().CheckSlot ();
			transform.position = eventData.position;
			transform.localScale = new Vector3 (1.2f, 1.2f, 1.2f);
			transform.localEulerAngles = new Vector3 (0, 0, 0);
			Deck.GetComponent<NbrCardsManager> ().StartDrag = true;
		}
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		
		Deck.GetComponent<NbrCardsManager> ().CheckSlot2 ();
		Deck.GetComponent<NbrCardsManager> ().StartDrag = false;
		itemBeingDragged = null;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		if(transform.parent == startParent){
			transform.localPosition = startPosition;
			transform.localRotation = startRotation;
			transform.localScale = startScale;
		}
	}

	#endregion



}
