using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class floatingDmg : MonoBehaviour {

	public GameObject floating;
	public bool dmg = false;
	public float speedfloating = 10f;
	public string dmgText;

	private Vector2 startposition;

	// Use this for initialization
	void Start () {
		startposition = floating.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (dmg) {
			floating.GetComponent<Text> ().text = "-"+dmgText;
			floating.transform.localPosition = Vector3.Lerp(floating.transform.localPosition, new Vector3(floating.transform.localPosition.x, 140f, floating.transform.localPosition.z), Time.deltaTime * speedfloating);
		}
		if (floating.transform.localPosition.y >= 138f) {
			dmg = false;
			floating.GetComponent<Text> ().text = "";
			floating.transform.localPosition = startposition;
		}
	}

	public void affiche(string text){
		dmgText = text;
		dmg = true;
	}
}
