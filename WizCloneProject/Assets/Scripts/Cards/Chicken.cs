using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Creature {

    public Chicken()
    {
        manacost = 1;
        attack = 1;
        health = 3;
        element = "water";
        icon = Resources.Load<Sprite>("CardIcons/chicken.png");

        cardname = "Chicken";
         description = "Chicken chicken chicken";
    }
}
