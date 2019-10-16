using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardsStatExample : MonoBehaviour {
	
	public int price;
	public int attack;
	public int health;
    public int atributo1;
    public int atributo2;
    public int atributo3;
    public int atributo4;
    public int atributo5;
    public int atributo6;
    public Sprite[] imgPrice;
	public Sprite[] imgAttack;
	public Sprite[] imgHealth;
    public Sprite[] imgatributo1;
    public Sprite[] imgatributo2;
    public Sprite[] imgatributo3;
    public Sprite[] imgatributo4;
    public Sprite[] imgatributo5;
    public Sprite[] imgatributo6;
    public GameObject objprice;
	public GameObject objattack;
	public GameObject objhealth;
    public GameObject objatributo1;
    public GameObject objatributo2;
    public GameObject objatributo3;
    public GameObject objatributo4;
    public GameObject objatributo5;
    public GameObject objatributo6;
    public bool boss = false;
	public bool mePositionForDeadLeft = false;
	public bool mePositionForDeadRight = false;
	public AudioClip loss;
	public AudioClip monsterHit;

	// Use this for initialization
	void Start () {
		if (!boss) {
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
				GetComponent<Rigidbody> ().AddForce (Vector3.left * 90000);
			} else if (mePositionForDeadRight) {
				GetComponent<Rigidbody> ().AddForce (Vector3.right * 90000f);
				GetComponent<Rigidbody> ().AddTorque(transform.up * 0f * 90000f);
			}
			GetComponent<BoxCollider> ().enabled = false;
			GetComponent<AudioSource> ().PlayOneShot (loss);
			(this.tag) = "EnemyMort";
            
		} else {
			objhealth.GetComponent<Image> ().sprite = imgHealth [health];
			GetComponent<AudioSource> ().PlayOneShot (monsterHit);
		}
	}

}
