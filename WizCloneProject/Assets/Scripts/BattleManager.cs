using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    public Player player, enemy;


	void Start ()
    {

	}
	
	void Update () {
		
	}

    public void SetPlayers(Player protagonist, Player antagonist)
    {
        player = protagonist;
        enemy = antagonist;
    }


}
