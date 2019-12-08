using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    // Your original list. Can be use to reset your list
    public List<Cartes> _originalList = new List<Cartes>();
    // List which will be used
    public List<Cartes> _numbersToGenerate = new List<Cartes>();
    public Image randomImage;
    public GameObject[] cartas;
    public Sprite[] images;
    //public List<int> atributos = new List<int>();
    //public int[][] atributos;
    int[,] atributos = new int[41,8];
    int num = 0;

    private void Start()
    {
        for (int x = 0; x < images.Length; x++)
        {
            for (int j = 0; j < 8; j++)
            {
                atributos[x, j] = Random.Range(0, 100);
            }
        }
    }

    public void aleatorio()
    {

        if (num < 3) {
            for (int i = 0; i < cartas.Length; i++)
            {
                var number = Random.Range(0, images.Length);
                //var number2 = Random.Range(10, 100);

                cartas[i].GetComponent<Image>().sprite = images[number];

                cartas[i].GetComponent<clickCard>().attack = atributos[number,0];
                cartas[i].GetComponent<clickCard>().velocidade = atributos[number,1];
                cartas[i].GetComponent<clickCard>().agilidade = atributos[number,2];
                cartas[i].GetComponent<clickCard>().inteligencia = atributos[number,3];

                cartas[i].GetComponent<clickCard>().attackdes = atributos[number,4];
                cartas[i].GetComponent<clickCard>().velocidadedes = atributos[number,5];
                cartas[i].GetComponent<clickCard>().agilidadedes = atributos[number,6];
                cartas[i].GetComponent<clickCard>().inteligenciades = atributos[number,7];

                cartas[i].GetComponent<clickCard>().objattack.GetComponent<Text>().text = (atributos[number,0]).ToString();
                cartas[i].GetComponent<clickCard>().objvelocidade.GetComponent<Text>().text = (atributos[number,1]).ToString();
                cartas[i].GetComponent<clickCard>().objagilidade.GetComponent<Text>().text = (atributos[number,2]).ToString();
                cartas[i].GetComponent<clickCard>().objinteligencia.GetComponent<Text>().text = (atributos[number,3]).ToString();

                cartas[i].GetComponent<clickCard>().objattackdes.GetComponent<Text>().text = (atributos[number,4]).ToString();
                cartas[i].GetComponent<clickCard>().objvelocidadedes.GetComponent<Text>().text = (atributos[number,5]).ToString();
                cartas[i].GetComponent<clickCard>().objagilidadedes.GetComponent<Text>().text = (atributos[number,6]).ToString();
                cartas[i].GetComponent<clickCard>().objinteligenciades.GetComponent<Text>().text = (atributos[number,7]).ToString();
            }
            num++;
        }
    }
}

//void Start()
//{
//images = new Sprite[8];
//images[0] = c0;
//images[1] = c1;
//images[2] = c2;
//images[3] = c3;
//images[4] = c4;
//images[5] = c5;
//images[6] = c6;
//images[7] = c7;
//}

//    public void shuffle()
//    {
//        // For 0 - 9

//        // Initializing original range. You can reset list by this
//        //for (int i = 0; i < 10; i++)
//        //   _originalList.Add();

//        // Assigning list to _numbersToGenerate list

//        _numbersToGenerate = _originalList;
//        showRandomImage();

//        // Getting unique numbers
//        for (int i = 0; i < _originalList.Count; i++)
//        {
//            int index = Random.Range(0, _numbersToGenerate.Count);
//            Cartes nextNumber = _numbersToGenerate[index];



//            print("Next Number: " + nextNumber.ToString());


//            // On DMGregory's advise for optimization. Replacing selected index with the last index
//            SwapElements(ref _numbersToGenerate, index, _numbersToGenerate.Count - 1);

//            _numbersToGenerate.RemoveAt(_numbersToGenerate.Count - 1);
//        }
//        Debug.Log("salada");
//        //showRandomImage();
//        // Reset it again
//        _numbersToGenerate = _originalList;
//    }

//    void SwapElements(ref List<Cartes> list, int index1, int index2)
//    {
//        Cartes tmp = list[index1];
//        list[index1] = list[index2];
//        list[index2] = tmp;
//    }
//    public void showRandomImage()
//    {
//        int num = UnityEngine.Random.Range(0, images.Length);
//        randomImage.sprite = images[num];    
//    }

//}

