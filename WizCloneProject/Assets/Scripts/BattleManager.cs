using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    public Player playerone, playertwo;

    public BattleUIManager battleuimanager;


	void Start ()
    {

	}
	
	void Update () {
		
	}

    public void SetPlayerToBattleManager(Player pone, Player ptwo)
    {
        playerone = pone;
        playertwo = ptwo;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
