using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.MonoBehaviour{

    GameManager gameManager;
    BattleLauncher battleLauncher;
    public string playername;


	void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		if (photonView.isMine)
        {
            battleLauncher = GameObject.FindGameObjectWithTag("BattleLauncher").GetComponent<BattleLauncher>();
            playername = battleLauncher.playername;
        }

        gameManager.init++;
	}
	
	void Update ()
    {
		
	}
}
