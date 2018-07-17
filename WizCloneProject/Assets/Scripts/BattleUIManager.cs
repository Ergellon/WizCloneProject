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
    public Text cardname, carddesciption;

    public List<Button> spellbookbuttons = new List<Button>();
    public List<Button> battlefieldplayerbuttons = new List<Button>();
    public List<Button> battlefieldenemybuttons = new List<Button>();

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
    public void UpdateBattleline()
    {

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
        playername.text = player.playername;
        enemyname.text = enemy.playername;
    }

    public void SetSpellbookUI()
    {
        Debug.Log("SpellbookUI started");
        for (int i = 0; i < player.spellbook.Count; i++)
        {

            Image[] images = new Image[6];
            images = spellbookbuttons[i].GetComponentsInChildren<Image>();
            for (int j = 0;j<6;j++)
            {
                if (images[j].name == "Icon")
                {
                    images[j].sprite = player.spellbook[i].icon;
                }
            }
            //spellbookbuttons[i].GetComponentInChildren<Image>().sprite = player.spellbook[i].icon;
            Button[] stats = new Button[4];
            stats = spellbookbuttons[i].GetComponentsInChildren<Button>();
            for (int j = 0; j<4;j++)
            {
                if (stats[j].name == "Sword")
                {
                    stats[j].GetComponentInChildren<Text>().text = player.spellbook[i].attack.ToString();
                    Debug.Log("sword");
                }
                else if (stats[j].name == "Drop")
                {
                    stats[j].GetComponentInChildren<Text>().text = player.spellbook[i].health.ToString();
                    Debug.Log("drop");
                }
                else if (stats[j].name == "Swirl")
                {
                    stats[j].GetComponentInChildren<Text>().text = player.spellbook[i].manacost.ToString();
                    Debug.Log("swirl");
                }
                else
                {
                    Debug.Log("error");
                }
            }

        }
    }

    public void CardSelectedUI(int n)
    {
        cardname.text = player.spellbook[n].cardname;
        carddesciption.text = player.spellbook[n].description;
    }
}
