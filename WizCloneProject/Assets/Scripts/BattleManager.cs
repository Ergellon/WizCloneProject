using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    public BattleUIManager battleUIManager;

    Player playerone, playertwo;

    Player attacker, defender;

	void Start ()
    {

	}
	
	void Update ()
    {
		
	}

    public void SetPlayer (Player pone, Player ptwo)
    {
        playerone = pone;
        playertwo = ptwo;
    }
}
