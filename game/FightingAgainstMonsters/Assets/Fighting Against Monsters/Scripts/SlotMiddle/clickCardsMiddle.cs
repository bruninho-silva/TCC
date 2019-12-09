using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEditor;
using DecisionMakerLib;
using System;

public class clickCardsMiddle : MonoBehaviour
{
        
    public bool sleep = false;
    public bool chooseForAttack = false;
    public bool Attack = false;
    public bool Returnstartposition = false;
    public bool mePositionForDeadLeft = false;
    public bool mePositionForDeadRight = false;

    public float speedAttack;
    public float middle;

    public CardsStatExample monster;
    public CheckSlotMiddle qtaslotsactive;
    public CheckSlotMiddle[] qtaslotsactivee;
    

    public GameObject sleepObj;
    public GameObject deck;
    public GameObject enemy;
    public GameObject Arrow;
    public GameObject[] slots;
    public CheckSlotMiddle slot;
    public GameObject atkd;
  
    


    public AudioClip loss;
    public AudioClip Sweep;

    public Vector2 startposition;


    // Use this for initialization
    void Start() { }
    //, IPointerClickHandler
    public void TaskOnClick()
    {
           
        List<Carta> cartas = new List<Carta>();
        LogicaParaconsistente paraconsistente = new LogicaParaconsistente();
        atkd.SetActive(false);

        if (middle == 4)
                {
                    for (int i = 0; i < slots.Length; i++)
                    {
                        if (slots[i].activeSelf)
                        {    
                            var price = slots[i].GetComponent<ApplyCardMiddle>().price;
                            var health = slots[i].GetComponent<ApplyCardMiddle>().health;

                            var attack = slots[i].GetComponent<ApplyCardMiddle>().attack;
                            var velocidade = slots[i].GetComponent<ApplyCardMiddle>().velocidade;
                            var agilidade = slots[i].GetComponent<ApplyCardMiddle>().agilidade;
                            var inteligencia  = slots[i].GetComponent<ApplyCardMiddle>().inteligencia;

                            var attackdes = slots[i].GetComponent<ApplyCardMiddle>().attackdes;
                            var velocidadedes = slots[i].GetComponent<ApplyCardMiddle>().velocidadedes;
                            var agilidadedes = slots[i].GetComponent<ApplyCardMiddle>().agilidadedes;
                            var inteligenciades = slots[i].GetComponent<ApplyCardMiddle>().inteligenciades;

                            cartas.Add(new Carta(attack, attackdes, velocidade, velocidadedes, agilidade, agilidadedes, inteligencia, inteligenciades));


                    //Debug.Log("Ataque=" + ataque + "Price=" + price + "Health=" + health);
                        slots[i].GetComponent<ApplyCardMiddle>().health -= deck.GetComponent<CardsStatExample>().Attack;
                    
                    }
             
            }
            var result = paraconsistente.ObtemPorcentagemDeDano(cartas);
            deck.GetComponent<CardsStatExample>().damage(result);
            //Carta cartaa = new Carta(myAL[0], myAL[1], myAL[2], myAL[3], myAL[4], myAL[5], myAL[6], myAL[7]);

        }
                else
                {
                    Debug.Log("Acrescenta mais 1");
                }

            }
        
   
    void Update()
    {
        middle = qtaslotsactive.GetComponent<CheckSlotMiddle>().NbrCardMiddle;


    }
}

  /*  void Update(){



		//IF NO ATTACK
		if(!Attack){
            Debug.Log("TESTE07");
            //IF NO SLEEPING
            if (!sleep) {
                Debug.Log("TESTE06");
                //IF THE CARD CHOOSE FOR ATTACK
                if (chooseForAttack) {
                    Debug.Log("TESTE05");
                    Arrow.GetComponent<Image>().enabled = true;
                    if (deck.GetComponent<CheckSlotMiddle> ().enemyObj) {
                        Debug.Log("TESTE04");
                        if (Input.GetMouseButtonDown(0)) {
                            Debug.Log("TESTE03");

                            enemy = deck.GetComponent<CheckSlotMiddle> ().enemyObj;
							enemy.GetComponent<overMouse> ().isAtacked = true;
							startposition = this.transform.localPosition;
							Attack = true;
							
							GetComponent<AudioSource> ().PlayOneShot (Sweep);

                            enemy.GetComponent<CardsStatExample>().damage(1000);


                        }
					}
				}
			}
		//IF ATTACK
		}else if (Attack) {
			
			if (!enemy.GetComponent<overMouse> ().impact) {
                Debug.Log("TESTE02");
                this.transform.localPosition = Vector3.Lerp (this.transform.localPosition, enemy.transform.localPosition, Time.deltaTime * speedAttack);
			} else {
                Debug.Log("TESTE01");
				Attack = false; 
				sleepObj.GetComponent<Image> ().enabled = true;
				enemy.GetComponent<overMouse> ().isAtacked = false;
                //var vidaInimigo = enemy.GetComponent<CardsStatExample>().health;

                //card1.SetActive(true);
                //var valorDoAtributo1 = card1.GetComponent<clickCardsMiddle>().Attack;
                //var valorDoAtributo2 = card1.GetComponent<clickCardsMiddle>().velocidade;

                //var valorDoAtribut2 = card2.GetComponent<clickCardsMiddle>().Attack;

                // var porcentagemDeVidaParaRemover = (paraconsistente.obtemValores() / 100);


                // enemy.GetComponent<CardsStatExample>().damage (porcentagemDeVidaParaRemover);
                //this.GetComponent<ApplyCardMiddle> ().damage (enemy.GetComponent<CardsStatExample> ().Attack);
                sleep = true;
				chooseForAttack = false;
				Returnstartposition = true;
				enemy.GetComponent<overMouse> ().impact = false;
                
			}
		}
		//RETRUN TO START POSITION
		if (Returnstartposition) {
			if (transform.localPosition.y > startposition.y) {
				StartCoroutine ("end");
				transform.localPosition = Vector3.Lerp (transform.localPosition, startposition, Time.deltaTime * speedAttack);
			}
		}
	}

	IEnumerator end(){
		yield return new WaitForSeconds (0.2f);
		Returnstartposition = false;
		enemy = null;
	}


	public void OnPointerClick(PointerEventData eventData){
		if (!sleep && !Attack) {
			Arrow.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y-50f, transform.localPosition.z);
			//Arrow.GetComponent<Image> ().enabled = true;
			chooseForAttack = true;
		}
	}*/


