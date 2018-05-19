using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Photon.MonoBehaviour, IPunObservable {

    public string playername = "defaultplayer_nonameloaded";

    public GameManager gamemanager;
    public GameObject gamemanagerobject;
    void Start () {
		
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
