using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.MonoBehaviour{

    GameLoader gameLoader;
    BattleLauncher battleLauncher;
    public string playername;

    public int health;
    public int fire, water, earth, air;


	void Start ()
    {
        health = 30;
        fire = water = earth = air = 1;
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
        }
        else
        {
            this.playername = (string)stream.ReceiveNext();
            this.health = (int)stream.ReceiveNext();
            this.fire = (int)stream.ReceiveNext();
            this.water = (int)stream.ReceiveNext();
            this.earth = (int)stream.ReceiveNext();
            this.air = (int)stream.ReceiveNext();
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
}
