using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour {

    Player player, enemy;

    public Text playername, enemyname;

    public Text playerhealth, enemyhealth;
    public Text playerfire, playerwater, playerearth, playerair;
    public Text enemyfire, enemywater, enemyearth, enemyair;

	void Start ()
    {
		
	}
	
	void Update ()
    {
      
    }

    public void UpdateStats()
    {
        playerhealth.text = player.health.ToString(); enemyhealth.text = enemy.health.ToString();
        playerfire.text = player.fire.ToString(); enemyfire.text = enemy.fire.ToString();
        playerwater.text = player.water.ToString(); enemywater.text = enemy.water.ToString();
        playerearth.text = player.earth.ToString(); enemyearth.text = enemy.earth.ToString();
        playerair.text = player.air.ToString(); enemyair.text = enemy.air.ToString();
    }
    public void SetPlayer(Player pone, Player ptwo)
    {
        if (pone.photonView.isMine)
        {
            player = pone;
            enemy = ptwo;
        }
        else
        {
            player = ptwo;
            enemy = pone;
        }
    }

    public void SetNames()
    {
        Debug.Log(enemy.playername);
        Debug.Log(player.playername);
        playername.text = player.playername;
        enemyname.text = enemy.playername;
    }
}
