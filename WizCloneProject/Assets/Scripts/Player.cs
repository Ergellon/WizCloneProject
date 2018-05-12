using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.PunBehaviour, IPunObservable {

    public int health = 30;

    bool isTurn = false;

    public int fire, water, earth, air;

	void Start () {
		
	}
	
	void Update ()
    {
		if (health<1)
        {
            GameManager.gameManager.LeaveRoom();
        }
        
	}

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(isTurn);
            stream.SendNext(health);
        }
        else
        {
            this.isTurn = (bool)stream.ReceiveNext();
            this.health = (int)stream.ReceiveNext();
        }

    }
}

