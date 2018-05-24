using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Creature {

	void Start ()
    {
    cardname = "chicken";
    description = "This is just an average chicken.";
    element = "earth";
    cost = 1;
    image = Resources.Load<Sprite>("Chicken");
        health = 2;
        attack = 1;
    }
	
}
