using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class OutlineCardsMiddle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	// Use this for initialization
	void Start () {
	
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		GetComponent<Outline> ().enabled = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		GetComponent<Outline> ().enabled = false;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
