using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Creature {

	void Start ()
    {
        name = "Cow";
        description = "Mooooooo";
        element = "water";
        cost = 1;
        image = Resources.Load<Sprite>("Cow");
    }
	

}
