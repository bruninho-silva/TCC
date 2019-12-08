using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class overMouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject deck;
    public GameObject paf;
    public CardsStatExample Matk;
    public bool impact = false;
    public bool isAtacked = false;
    public AudioClip impacte;


    // Use this for initialization
    void Start()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        deck.GetComponent<CheckSlotMiddle>().tagOverUI = this.tag;
        if (this.tag == "Enemy")
        {

            deck.GetComponent<CheckSlotMiddle>().enemyObj = this.gameObject;

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        deck.GetComponent<CheckSlotMiddle>().tagOverUI = "";
        deck.GetComponent<CheckSlotMiddle>().enemyObj = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "posed" && isAtacked)
        {

            impact = true;
            paf.SetActive(true);
            StartCoroutine("pafend");
            GetComponent<AudioSource>().PlayOneShot(impacte);

        }

    }

        IEnumerator pafend()
        {
            yield return new WaitForSeconds(0.05f);
            paf.SetActive(false);
        }


    }




