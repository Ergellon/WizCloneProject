using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour {

    public Player player, enemy;

    public Text playernamefield, enemynamefield;

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void SetPlayerToUIManager (Player pone, Player ptwo)
    {
        if(pone.photonView.isMine)
        {
            player = pone;
            enemy = ptwo;
        }
        else if (ptwo.photonView.isMine)
        {
            player = ptwo;
            enemy = pone;

        }
        else
        {
            Debug.LogWarning("No player found for UI");
        }
    }
    public void SetNames()
    {
        playernamefield.text = player.playername;
        enemynamefield.text = enemy.playername;
    }
}
