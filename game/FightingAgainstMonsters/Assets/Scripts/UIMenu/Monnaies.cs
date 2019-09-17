using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Monnaies : MonoBehaviour {

	public GameObject Textmonnaies;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool reduc(int nbr){
		int gold = int.Parse (Textmonnaies.GetComponent<Text> ().text);
		int newgold = gold - nbr;
		if (newgold >= 0) {
			Textmonnaies.GetComponent<Text> ().text = newgold.ToString ();
			return true;
		} else {
			return false;
		}
	}
}
