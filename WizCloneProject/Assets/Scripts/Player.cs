using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Photon.MonoBehaviour, IPunObservable {

    public string playername = "nonameloaded";

    public GameManager gamemanager;
    public GameObject gamemanagerobject;

    public BattleLauncher battlelauncher;

    void Start ()
    {

	}
	
	void Update () {
		
	}

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        /*if (stream.isWriting)
        {
            stream.SendNext(playername);
        }
        else
        {
            this.playername =(string) stream.ReceiveNext();
        }
        */
    }

    void OnPhotonInstantiate (PhotonMessageInfo info)
    {
        battlelauncher = GameObject.FindGameObjectWithTag("BattleLauncher").GetComponent<BattleLauncher>();
        playername = battlelauncher.playername;
        Debug.Log(playername);
        gamemanagerobject = GameObject.FindGameObjectWithTag("GameManager");
        gamemanager = gamemanagerobject.GetComponent<GameManager>();
        gamemanager.SetPlayer(this);
    }


}
