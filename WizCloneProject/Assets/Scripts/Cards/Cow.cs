using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Creature {


    public Cow()
    {
        manacost = 1;
        attack = 1;
        health = 3;
        element = "earth";
        icon  = Resources.Load<Sprite>("CardIcons/cow.png");

        cardname = "cow";
        description = "cow cow cow";
    }
}
