using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<clickCard> cardList = new List<clickCard>();

    void Awake()
    {

        cardList.Add(new clickCard(0, 15, 4, 30, Resources.Load<Sprite>("1")));
        cardList.Add(new clickCard(1, 10, 6, 28, Resources.Load<Sprite>("2")));
        cardList.Add(new clickCard(2, 19, 8, 22, Resources.Load<Sprite>("3")));
        cardList.Add(new clickCard(3, 21, 5, 52, Resources.Load<Sprite>("4")));
        cardList.Add(new clickCard(4, 30, 10, 45, Resources.Load<Sprite>("5")));
        cardList.Add(new clickCard(5, 9, 1, 5, Resources.Load<Sprite>("6")));
        cardList.Add(new clickCard(6, 6, 2, 8, Resources.Load<Sprite>("7")));
        cardList.Add(new clickCard(7, 7, 3, 12, Resources.Load<Sprite>("8")));

    }


}
