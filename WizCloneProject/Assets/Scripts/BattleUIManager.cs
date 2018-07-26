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

    public List<GameObject> playerbattleline = new List<GameObject>();
    public List<GameObject> enemybattleline = new List<GameObject>();

    public Text[] playercreatureattack = new Text[7];
    public Text[] enemycreatureattack = new Text[7];
    public Text[] playercreaturehealth = new Text[7];
    public Text[] enemycreaturehealth = new Text[7];
    public Text[] playercreaturecost = new Text[7];
    public Text[] enemycreaturecost = new Text[7];

    public Image[] playercreatureicon = new Image[7];
    public Image[] enemycreatureicon = new Image[7];


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
        for (int i = 0; i < 7; i++)
        {
            if(player.battlelinefilling[i] == true)
            {
                Debug.Log(i);
                playerbattleline[i].SetActive(true);
                playercreatureattack[i].text = player.battleline[i].attack.ToString();         
                playercreaturehealth[i].text = player.battleline[i].health.ToString();
                playercreaturecost[i].text = player.battleline[i].manacost.ToString();
                playercreatureicon[i].sprite = player.battleline[i].icon;
            }
            if (enemy.battlelinefilling[i] == true)
            {
                Debug.Log(i);
                enemybattleline[i].SetActive(true);
                //enemycreatureattack[i].text = "kekekeke";
                enemycreatureattack[i].text = enemy.battleline[i].attack.ToString();
                enemycreaturehealth[i].text = enemy.battleline[i].health.ToString();
                enemycreaturecost[i].text = enemy.battleline[i].manacost.ToString();
                enemycreatureicon[i].sprite = enemy.battleline[i].icon;
            }

        }

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
                }
                else if (stats[j].name == "Drop")
                {
                    stats[j].GetComponentInChildren<Text>().text = player.spellbook[i].health.ToString();
                }
                else if (stats[j].name == "Swirl")
                {
                    stats[j].GetComponentInChildren<Text>().text = player.spellbook[i].manacost.ToString();
                }
                else
                {
                }
            }

        }
    }

    public void CardSelectedUI(int n)
    {
        cardname.text = player.spellbook[n].cardname;
        carddesciption.text = player.spellbook[n].description;
    }
    public void RemoveCreatureOnUI(Player p, int slot)
    {
        if (p == player)
        {
            playerbattleline[slot].SetActive(false);
        }
        else
        {
            enemybattleline[slot].SetActive(false);
        }
    }
}
