using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour {

    public Player player, enemy;

    public Text playernamefield, enemynamefield;

    public Text playerhealth, enemyhealth;
    public Text playerfire, enemyfire, playerwater, enemywater, playerearth, enemyearth, playerair, enemyair;

    public Text cardinfo;

    public List<Button> spellbook = new List<Button>();
    public List<Button> playercreatures = new List<Button>();
    public List<Button> enemycreatures = new List<Button>();

    public bool namesset = false;


	void Start () {
		
	}
	
	void Update ()
    {
        SetNames(); // must be fixed later

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
        for (int i = 0; i<24; i++) // there are 24 cards in game, magic number
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
                Debug.Log("Settinginfo");

            }
            if (t[i].name == "Attack")
            {
                t[i].text = c.attack.ToString();
                Debug.Log("Settinginfo");

            }
            if (t[i].name == "Manacost")
            {
                t[i].text = c.cost.ToString();
                Debug.Log("Settinginfo");

            }
        }

        Image[] images = new Image[4];
        images = b.GetComponentsInChildren<Image>();
        for(int i = 0; i<3;i++)
        {
            if(images[i].name == "Creature Image")
            {
                images[i].sprite = c.image;
            }
        }

        
    }

    public void ShowDescription (Button b)
    {
        for (int i = 0; i<24;i++)
        {
            if(b == spellbook[i])
            {
                cardinfo.text = player.spellbook[i].description;
            }
        }
    }

    public void PlaceCreature(int number, Creature c)
    {
        playercreatures[number].image.sprite = c.image;

        Text[] t = new Text[3];
        t = playercreatures[number].GetComponentsInChildren<Text>();
        for (int i = 0; i < 3; i++)
        {
            if (t[i].name == "Health")
            {
                t[i].text = c.health.ToString();
            }
            if (t[i].name == "Attack")
            {
                t[i].text = c.attack.ToString();
                
            }

        }
    }
    public void UpdateField()
    {

    }
}
