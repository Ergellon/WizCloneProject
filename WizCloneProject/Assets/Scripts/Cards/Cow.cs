using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Creature {

	void Start ()
    {
      /*  cardname = "Cow";
        description = "Mooooooo";
        element = "water";
        cost = 1;
        image = Resources.Load<Sprite>("Cow");
         health = 5;
        attack = 1;
        */

    }
	
    public Cow()
    {
        cardname = "Cow";
        description = "Mooooooo";
        element = "water";
        cost = 1;
        image = Resources.Load<Sprite>("Cow");
        health = 5;
        attack = 1;

    }

}
