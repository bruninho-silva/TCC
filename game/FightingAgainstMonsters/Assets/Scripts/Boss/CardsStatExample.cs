using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardsStatExample : MonoBehaviour {
	
	public int price;
	public int attack;
	public int health;
	public Sprite[] imgPrice;
	public Sprite[] imgAttack;
	public Sprite[] imgHealth;
	public GameObject objprice;
	public GameObject objattack;
	public GameObject objhealth;
	public bool boss = false;

	public bool mePositionForDeadLeft = false;
	public bool mePositionForDeadRight = false;
	public AudioClip loss;
	public AudioClip monsterHit;

	// Use this for initialization
	void Start () {
		if (!boss) {
			objprice.GetComponent<Image> ().sprite = imgPrice [price];
			objattack.GetComponent<Image> ().sprite = imgAttack [attack];
		}
		objhealth.GetComponent<Image> ().sprite = imgHealth [health];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void damage(int dmg){
		health -= dmg;
		GetComponent<floatingDmg> ().affiche(dmg.ToString());

		if (health <= 0) {
			objhealth.GetComponent<Image> ().sprite = imgHealth [0];
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionZ;
			if (mePositionForDeadLeft) {
				GetComponent<Rigidbody> ().AddForce (Vector3.left * 3000f);
			} else if (mePositionForDeadRight) {
				GetComponent<Rigidbody> ().AddForce (Vector3.right * 3000f);
				GetComponent<Rigidbody> ().AddTorque(transform.up * 0f * 300f);
			}
			GetComponent<BoxCollider> ().enabled = false;
			GetComponent<AudioSource> ().PlayOneShot (loss);
			this.tag = "EnemyMort";
		} else {
			objhealth.GetComponent<Image> ().sprite = imgHealth [health];
			GetComponent<AudioSource> ().PlayOneShot (monsterHit);
		}
	}

}
