using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class clickStart : MonoBehaviour , IPointerClickHandler {

    

 
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnPointerClick(PointerEventData eventData){
		Application.LoadLevel("index");
	}
}
