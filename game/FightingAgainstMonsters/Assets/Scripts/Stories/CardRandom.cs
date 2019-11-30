using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRandom : MonoBehaviour
{

    public int idrand;
    public int attackrand;
    public int healthrand;
    public int pricerand;

    public Sprite imagerand;

    public CardRandom()
    {

    }

    public CardRandom(int idran, int atkran, int hpran, int priceran, Sprite imgrand)
    {
        idrand = idran;
        attackrand = atkran;
        healthrand = hpran;
        pricerand = priceran;
        imagerand = imgrand;


    }

}
