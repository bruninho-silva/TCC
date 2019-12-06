using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    // Your original list. Can be use to reset your list
    public List<Cartes> _originalList = new List<Cartes>();
    // List which will be used
    public List<Cartes> _numbersToGenerate = new List<Cartes>();

    public void shuffle()
    {
        // For 0 - 9

        // Initializing original range. You can reset list by this
        //for (int i = 0; i < 10; i++)
         //   _originalList.Add();

        // Assigning list to _numbersToGenerate list
        _numbersToGenerate = _originalList;

        // Getting unique numbers
        for (int i = 0; i < _originalList.Count; i++)
        {
            int index = Random.Range(0, _numbersToGenerate.Count);
            Cartes nextNumber = _numbersToGenerate[index];

            print("Next Number: " + nextNumber.ToString());

            // On DMGregory's advise for optimization. Replacing selected index with the last index
            SwapElements(ref _numbersToGenerate, index, _numbersToGenerate.Count - 1);

            _numbersToGenerate.RemoveAt(_numbersToGenerate.Count - 1);
        }

        // Reset it again
        _numbersToGenerate = _originalList;
    }

    void SwapElements(ref List<Cartes> list, int index1, int index2)
    {
        Cartes tmp = list[index1];
        list[index1] = list[index2];
        list[index2] = tmp;
    }
}

