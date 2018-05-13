using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ConnectionLauncher : Photon.PunBehaviour {

    string gameversion = "0.01";

    public GameObject connecting;

    void Awake()
    {
        PhotonNetwork.automaticallySyncScene = true; 
    }

    void Start () {
		
	}
	
	void Update () {
		
	}

    public void Connect ()
    {
        connecting.SetActive(true);
        
        if (PhotonNetwork.connectedAndReady)
        {
            PhotonNetwork.JoinRandomRoom(); //maybe try JoinOrCreate later
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings(gameversion);
        }
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        PhotonNetwork.CreateRoom(null);
    }



}
