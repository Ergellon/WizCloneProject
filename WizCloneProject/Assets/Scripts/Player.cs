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
        battlelauncher = GameObject.FindGameObjectWithTag("BattleLauncher").GetComponent<BattleLauncher>();
        playername = battlelauncher.playername;
	}
	
	void Update () {
		
	}

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
    }

    void OnPhotonInstantiate (PhotonMessageInfo info)
    {
        gamemanagerobject = GameObject.FindGameObjectWithTag("GameManager");
        gamemanager = gamemanagerobject.GetComponent<GameManager>();
        gamemanager.SetPlayer(this);
        
    }


}
