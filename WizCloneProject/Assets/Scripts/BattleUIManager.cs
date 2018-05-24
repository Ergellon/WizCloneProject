using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour {

    public Player player, enemy;

    public Text playernamefield, enemynamefield;

    public Text playerhealth, enemyhealth;
    public Text playerfire, enemyfire, playerwater, enemywater, playerearth, enemyearth, playerair, enemyair;

    public List<Button> spellbook = new List<Button>();
    public List<Button> playercreatures = new List<Button>();
    public List<Button> enemycreatures = new List<Button>();


    public bool namesset = false;

	void Start () {
		
	}
	
	void Update ()
    {
            SetNames();
            namesset = true;
        playerhealth.text = player.health.ToString();
        enemyhealth.text = enemy.health.ToString();

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
    
    public void ChangeMana()
    {
        playerfire.text = player.fire.ToString();
        enemyfire.text = enemy.fire.ToString();

        playerwater.text = player.water.ToString();
        enemywater.text = enemy.water.ToString();

        playerearth.text = player.earth.ToString();
        enemyearth.text = enemy.earth.ToString();

        playerair.text = player.air.ToString();
        enemyair.text = enemy.air.ToString();
    }
    public void SetSpellbook()
    {
        for (int i = 0; i<25; i++) // there are 24 cards in game, magic number
        {
            
            SetCard(spellbook[i], player.spellbook[i]);
        }
    }
    public void SetCard(Button b, Creature c)
    {
        Text[] t = new Text[3];
        t = b.GetComponentsInChildren<Text>();
        for (int i = 0; i<3; i++)
        {
            if(t[i].name == "Health")
            {
                t[i].text =  c.health.ToString();
            }
            if (t[i].name == "Attack")
            {
                t[i].text = c.attack.ToString();
            }
            if (t[i].name == "Manacost")
            {
                t[i].text = c.cost.ToString();
            }
        }
        
    }

}
