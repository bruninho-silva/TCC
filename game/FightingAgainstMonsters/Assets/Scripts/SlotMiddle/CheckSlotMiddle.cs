using UnityEngine;
using System.Collections;

public class CheckSlotMiddle : MonoBehaviour {

	public int NbrCardMiddle = 0;
	public GameObject[] slotmiddle;
	public float speedRangeCards = 5.0F;
	public Vector3 PoseCard;
	public bool ApplyMiddleCards = false;

	public string tagOverUI;
	public GameObject enemyObj;
	public GameObject DeckManager;
	public AudioClip pose;

	// Use this for initialization
	void Start () {
	
	}

	public void playsoundPose(){
		GetComponent<AudioSource> ().PlayOneShot (pose);
	}

	// Update is called once per frame
	void Update () {
		if (!ApplyMiddleCards) {
			if (NbrCardMiddle == 1) {
				
				slotmiddle [0].SetActive (true);
				slotmiddle [0].transform.localPosition = new Vector3 (0, 0, 0);
				ApplyMiddleCards = true;

			} else if (NbrCardMiddle == 2) {
				
				slotmiddle [1].SetActive (true);
				if (PoseCard.x < 0f) {
					slotmiddle [0].transform.localPosition = Vector3.Lerp (slotmiddle [0].transform.localPosition, new Vector3 (65, 0, 0), Time.deltaTime * speedRangeCards);
					slotmiddle [1].transform.localPosition = Vector3.Lerp (slotmiddle [1].transform.localPosition, new Vector3 (-65, 0, 0), Time.deltaTime * speedRangeCards);
					if (slotmiddle [1].transform.localPosition.x == -65) {
						ApplyMiddleCards = true;
					}
				} else if (PoseCard.x >= 0f) {
					slotmiddle [0].transform.localPosition = Vector3.Lerp (slotmiddle [0].transform.localPosition, new Vector3 (-65, 0, 0), Time.deltaTime * speedRangeCards);
					slotmiddle [1].transform.localPosition = Vector3.Lerp (slotmiddle [1].transform.localPosition, new Vector3 (65, 0, 0), Time.deltaTime * speedRangeCards);
					if (slotmiddle [1].transform.localPosition.x == 65) {
						ApplyMiddleCards = true;
					}
				}

			} else if (NbrCardMiddle == 3) {
				slotmiddle [2].SetActive (true);
				if (PoseCard.x < -65f) {
					slotmiddle [2].transform.localPosition = new Vector3 (-130, 0, 0);
					if (slotmiddle [2].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [2].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (0, 0, 0);
						slotmiddle [2].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (130, 0, 0);
						if (slotmiddle [2].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 130) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= -65f && PoseCard.x < 65f) {
					slotmiddle [2].transform.localPosition = new Vector3 (0, 0, 0);
					if (slotmiddle [2].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [2].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-130, 0, 0);
					}
					if (slotmiddle [2].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [2].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (130, 0, 0);
						if (slotmiddle [2].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 130) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= 65f) {
					slotmiddle [2].transform.localPosition = new Vector3 (130, 0, 0);
					if (slotmiddle [2].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [2].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (0, 0, 0);
						slotmiddle [2].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-130, 0, 0);
						if (slotmiddle [2].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition.x == -130) {
							ApplyMiddleCards = true;
						}
					}
				}

			} else if (NbrCardMiddle == 4) {
				slotmiddle [3].SetActive (true);
				if (PoseCard.x < -130f) {
					slotmiddle [3].transform.localPosition = new Vector3 (-195, 0, 0);
					if (slotmiddle [3].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [3].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (-65, 0, 0);
						slotmiddle [3].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (65, 0, 0);
						slotmiddle [3].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (195, 0, 0);
						if (slotmiddle [3].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 195) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= -130f && PoseCard.x < -65f) {
					slotmiddle [3].transform.localPosition = new Vector3 (-65, 0, 0);
					if (slotmiddle [3].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [3].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-195, 0, 0);
					}
					if (slotmiddle [3].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [3].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (65, 0, 0);
						slotmiddle [3].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (195, 0, 0);
						if (slotmiddle [3].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 195) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= -65f && PoseCard.x < 0f) {
					slotmiddle [3].transform.localPosition = new Vector3 (-65, 0, 0);
					if (slotmiddle [3].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [3].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-195, 0, 0);
					}
					if (slotmiddle [3].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [3].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (65, 0, 0);
						slotmiddle [3].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (195, 0, 0);
						if (slotmiddle [3].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 195) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= 0f && PoseCard.x < 65f) {
					slotmiddle [3].transform.localPosition = new Vector3 (65, 0, 0);
					if (slotmiddle [3].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [3].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-65, 0, 0);
						slotmiddle [3].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-195, 0, 0);
					}
					if (slotmiddle [3].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [3].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().transform.localPosition = new Vector3 (195, 0, 0);
						if (slotmiddle [3].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().transform.localPosition.x == 195) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= 65f && PoseCard.x < 130f) {
					slotmiddle [3].transform.localPosition = new Vector3 (65, 0, 0);
					if (slotmiddle [3].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [3].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-65, 0, 0);
						slotmiddle [3].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-195, 0, 0);
					}
					if (slotmiddle [3].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [3].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().transform.localPosition = new Vector3 (195, 0, 0);
						if (slotmiddle [3].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().transform.localPosition.x == 195) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= 130f) {
					slotmiddle [3].transform.localPosition = new Vector3 (195, 0, 0);
					if (slotmiddle [3].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [3].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (65, 0, 0);
						slotmiddle [3].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-65, 0, 0);
						slotmiddle [3].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-195, 0, 0);
						if (slotmiddle [3].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition.x == -195) {
							ApplyMiddleCards = true;
						}
					}
				}

			} else if (NbrCardMiddle == 5) {

				slotmiddle [4].SetActive (true);
				if (PoseCard.x < -195f) {
					slotmiddle [4].transform.localPosition = new Vector3 (-260, 0, 0);
					if (slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (-130, 0, 0);
						slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (0, 0, 0);
						slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (130, 0, 0);
						slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (260, 0, 0);
						if (slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 260) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= -195f && PoseCard.x < -130f) {
				
					slotmiddle [4].transform.localPosition = new Vector3 (-130, 0, 0);
					if (slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-260, 0, 0);
					}
					if (slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (0, 0, 0);
						slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (130, 0, 0);
						slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (260, 0, 0);
						if (slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 260) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= -130f && PoseCard.x < -65f) {

					slotmiddle [4].transform.localPosition = new Vector3 (-130, 0, 0);
					if (slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-260, 0, 0);
					}
					if (slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (0, 0, 0);
						slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (130, 0, 0);
						slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (260, 0, 0);
						if (slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 260) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= -65f && PoseCard.x < 0f) {
					slotmiddle [4].transform.localPosition = new Vector3 (0, 0, 0);
					if (slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-130, 0, 0);
						slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-260, 0, 0);
					}
					if (slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (130, 0, 0);
						slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (260, 0, 0);
						if (slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 260) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= 0f && PoseCard.x < 65f) {
					slotmiddle [4].transform.localPosition = new Vector3 (0, 0, 0);
					if (slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-130, 0, 0);
						slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-260, 0, 0);
					}
					if (slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (130, 0, 0);
						slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (260, 0, 0);
						if (slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 260) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= 65f && PoseCard.x < 130f) {
					slotmiddle [4].transform.localPosition = new Vector3 (130, 0, 0);
					if (slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (0, 0, 0);
						slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-130, 0, 0);
						slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-260, 0, 0);
					}
					if (slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (260, 0, 0);
						if (slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 260) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= 130f && PoseCard.x < 195f) {
					slotmiddle [4].transform.localPosition = new Vector3 (130, 0, 0);
					if (slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (0, 0, 0);
						slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-130, 0, 0);
						slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-260, 0, 0);
					}
					if (slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (260, 0, 0);
						if (slotmiddle [4].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 260) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x > 195f) {
					slotmiddle [4].transform.localPosition = new Vector3 (260, 0, 0);
					if (slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (130, 0, 0);
						slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (0, 0, 0);
						slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-130, 0, 0);
						slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-260, 0, 0);
						if (slotmiddle [4].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition.x == -260) {
							ApplyMiddleCards = true;
						}
					}
				}
			}else if (NbrCardMiddle == 6) {

				slotmiddle [5].SetActive (true);
				if (PoseCard.x < -260) {
					slotmiddle [5].transform.localPosition = new Vector3 (-325, 0, 0);
					if (slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (-195, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (-65, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (65, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (195, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (325, 0, 0);
						if (slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 325) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= -260 && PoseCard.x < -195f) {

					slotmiddle [5].transform.localPosition = new Vector3 (-195, 0, 0);
					if (slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-325, 0, 0);
					}
					if (slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (-65, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (65, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (195, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (325, 0, 0);
						if (slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 325) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= -195f && PoseCard.x < -65f) {
					slotmiddle [5].transform.localPosition = new Vector3 (-65, 0, 0);
					if (slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-195, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-325, 0, 0);
					}
					if (slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (65, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (195, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (325, 0, 0);
						if (slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 325) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= -65f && PoseCard.x < 0f) {
					slotmiddle [5].transform.localPosition = new Vector3 (-65, 0, 0);
					if (slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-195, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-325, 0, 0);
					}
					if (slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (65, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (195, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (325, 0, 0);
						if (slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 325) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= 0f && PoseCard.x < 65f) {
					slotmiddle [5].transform.localPosition = new Vector3 (65, 0, 0);
					if (slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-65, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-195, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-325, 0, 0);
					}
					if (slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (195, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (325, 0, 0);
						if (slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 325) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= 65f && PoseCard.x < 195f) {
					slotmiddle [5].transform.localPosition = new Vector3 (65, 0, 0);
					if (slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-65, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-195, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-325, 0, 0);
					}
					if (slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (195, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (325, 0, 0);
						if (slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 325) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= 195f && PoseCard.x < 260f) {
					slotmiddle [5].transform.localPosition = new Vector3 (195, 0, 0);
					if (slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (65, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-65, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-195, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-325, 0, 0);
					}
					if (slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (325, 0, 0);
						if (slotmiddle [5].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 325) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x > 260f) {
					slotmiddle [5].transform.localPosition = new Vector3 (325, 0, 0);
					if (slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (195, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (65, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-65, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-195, 0, 0);
						slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-325, 0, 0);
						if (slotmiddle [5].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition.x == -325) {
							ApplyMiddleCards = true;
						}
					}
				}
			} else if (NbrCardMiddle == 7) {

				slotmiddle [6].SetActive (true);
				if (PoseCard.x < -325) {
					slotmiddle [6].transform.localPosition = new Vector3 (-390, 0, 0);
					if (slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (-260, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (-130, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (0, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (130, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (260, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (390, 0, 0);
						if (slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 390) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= -325 && PoseCard.x < -260f) {

					slotmiddle [6].transform.localPosition = new Vector3 (-260, 0, 0);
					if (slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-390, 0, 0);
					}
					if (slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (-130, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (0, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (130, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (260, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (390, 0, 0);
						if (slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 390) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= -260 && PoseCard.x < -195f) {

					slotmiddle [6].transform.localPosition = new Vector3 (-260, 0, 0);
					if (slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-390, 0, 0);
					}
					if (slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (-130, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (0, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (130, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (260, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (390, 0, 0);
						if (slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 390) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= -195f && PoseCard.x < -130f) {
					slotmiddle [6].transform.localPosition = new Vector3 (-130, 0, 0);
					if (slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-260, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-390, 0, 0);
					}
					if (slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (0, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (130, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (260, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (390, 0, 0);
						if (slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 390) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= -130f && PoseCard.x < -65f) {
					slotmiddle [6].transform.localPosition = new Vector3 (-130, 0, 0);
					if (slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-260, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-390, 0, 0);
					}
					if (slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (0, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (130, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (260, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (390, 0, 0);
						if (slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 390) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= -65f && PoseCard.x < 0f) {
					slotmiddle [6].transform.localPosition = new Vector3 (0, 0, 0);
					if (slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-130, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-260, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-390, 0, 0);
					}
					if (slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (130, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (260, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (390, 0, 0);
						if (slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 390) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= 0f && PoseCard.x < 65f) {
					slotmiddle [6].transform.localPosition = new Vector3 (0, 0, 0);
					if (slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-130, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-260, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-390, 0, 0);
					}
					if (slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (130, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (260, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (390, 0, 0);
						if (slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 390) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= 65f && PoseCard.x < 130f) {
					slotmiddle [6].transform.localPosition = new Vector3 (130, 0, 0);
					if (slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (0, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-130, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-260, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-390, 0, 0);
					}
					if (slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (260, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (390, 0, 0);
						if (slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 390) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= 130f && PoseCard.x < 195f) {
					slotmiddle [6].transform.localPosition = new Vector3 (130, 0, 0);
					if (slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (0, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-130, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-260, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-390, 0, 0);
					}
					if (slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (260, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (390, 0, 0);
						if (slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 390) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x >= 195f && PoseCard.x < 260f) {
					slotmiddle [6].transform.localPosition = new Vector3 (260, 0, 0);
					if (slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (130, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (0, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-130, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-260, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-390, 0, 0);
					}
					if (slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (390, 0, 0);
						if (slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 390) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x > 260f && PoseCard.x < 325f) {
					slotmiddle [6].transform.localPosition = new Vector3 (260, 0, 0);
					if (slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (130, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (0, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-130, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-260, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-390, 0, 0);
					}
					if (slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj != null) {
						slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition = new Vector3 (390, 0, 0);
						if (slotmiddle [6].GetComponent<BoxRaycasting> ().Rightobj.transform.localPosition.x == 390) {
							ApplyMiddleCards = true;
						}
					}
				} else if (PoseCard.x > 325f) {
					slotmiddle [6].transform.localPosition = new Vector3 (390, 0, 0);
					if (slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj != null) {
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (260, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (130, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (0, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-130, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-260, 0, 0);
						slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition = new Vector3 (-390, 0, 0);
						if (slotmiddle [6].GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.GetComponent<BoxRaycasting> ().Leftobj.transform.localPosition.x == -390) {
							ApplyMiddleCards = true;
						}
					}
				}
			}
		}
	}
}
