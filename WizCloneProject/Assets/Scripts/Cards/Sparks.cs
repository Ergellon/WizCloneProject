using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparks : Spell {


    public Sparks()
    {
        manacost = 1;
        power = 1;

        element = "air";
        icon = Resources.Load<Sprite>("CardIcons/magic-palm");

        cardname = "Sparks";
        description = "sparks sparks sparks";
}   

}
