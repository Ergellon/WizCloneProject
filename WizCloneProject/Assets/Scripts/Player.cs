using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.MonoBehaviour{

    GameLoader gameLoader;
    BattleLauncher battleLauncher;
    public string playername;

    public int health;
    public int fire, water, earth, air;
    public bool hasturn;

    //Card[] spellbook = new Card[24];

    public Creature[] battleline = new Creature[7];
    public bool[] battlelinefilling = new bool[7];

    public List<Card> spellbook = new List<Card>();
    //List<Creature> battleline = new List<Creature>();
    //List<bool> battlelinefilling = new List<bool>();


	void Start ()
    {
        health = 30;
        fire = water = earth = air = 1;
        hasturn = false;
        for (int i = 0; i<7; i++)
        {
            battlelinefilling[i] = false;
        }
        FillSpellbook();
        Debug.Log("Spellbook filled");
    }
	
	void Update ()
    {
		
	}

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(playername);
            stream.SendNext(health);
            stream.SendNext(fire);
            stream.SendNext(water);
            stream.SendNext(earth);
            stream.SendNext(air);
            stream.SendNext(hasturn);
            for(int i = 0; i<7; i++)
            {
                stream.SendNext(battlelinefilling[i]);
            }
            
        }
        else
        {
            this.playername = (string)stream.ReceiveNext();
            this.health = (int)stream.ReceiveNext();
            this.fire = (int)stream.ReceiveNext();
            this.water = (int)stream.ReceiveNext();
            this.earth = (int)stream.ReceiveNext();
            this.air = (int)stream.ReceiveNext();
            this.hasturn = (bool)stream.ReceiveNext();
            for (int i = 0; i < 7; i++)
            {
                this.battlelinefilling[i] = (bool)stream.ReceiveNext();
            }
            
        }
    }
    
    void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        if (photonView.isMine)
        {
            battleLauncher = GameObject.FindGameObjectWithTag("BattleLauncher").GetComponent<BattleLauncher>();
            playername = battleLauncher.playername;
        }
        gameLoader = GameObject.FindGameObjectWithTag("GameLoader").GetComponent<GameLoader>();
        gameLoader.playersready++;
    }

    public void ChangeHealth(int n)
    {
        health += n;
    }
    public void IncreaseMana()
    {
        fire++;water++;earth++;air++;
    }
    public void FillSpellbook()
    {
        spellbook.Add(new Chicken());
        spellbook.Add(new Chicken());
        spellbook.Add(new Chicken());
        spellbook.Add(new Chicken());
        spellbook.Add(new Chicken());
        spellbook.Add(new Chicken());

        spellbook.Add(new Chicken());
        spellbook.Add(new Chicken());
        spellbook.Add(new Chicken());
        spellbook.Add(new Chicken());
        spellbook.Add(new Chicken());
        spellbook.Add(new Sparks());

        spellbook.Add(new Chicken());
        spellbook.Add(new Chicken());
        spellbook.Add(new Chicken());
        spellbook.Add(new Chicken());
        spellbook.Add(new Chicken());
        spellbook.Add(new Cow());

        spellbook.Add(new Chicken());
        spellbook.Add(new Chicken());
        spellbook.Add(new Chicken());
        spellbook.Add(new Chicken());
        spellbook.Add(new Cow());
        spellbook.Add(new Cow());

    }

   /* [PunRPC]
    public void ChangeTurn()
    {
        Debug.Log("Turn function started");
        if (hasturn == true) 
        {
            hasturn = false;
        }
        else
        {
            IncreaseMana();
            hasturn = true;
        }
    }
    */
}


