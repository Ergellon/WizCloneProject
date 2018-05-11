using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : Photon.PunBehaviour {


    string gameVersion = "0.01";
    bool isconnecting;


    public GameObject panel;
    public GameObject connecting;




    void Awake()
    {
        PhotonNetwork.autoJoinLobby = false;
        PhotonNetwork.automaticallySyncScene = true;

    }

    void Start ()
    {
        connecting.SetActive(false);
	}	

	void Update ()
    {
		
	}

    public void Connect ()
    {
        isconnecting = true;
        panel.SetActive(false);
        connecting.SetActive(true);
        if (PhotonNetwork.connected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings(gameVersion);
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("connected");
        if (isconnecting)
        {
            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnDisconnectedFromPhoton()
    {
        Debug.Log("disconnected from photon");
        connecting.SetActive(false);
        panel.SetActive(true);
    }
    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 2 }, null);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("room joined");
        PhotonNetwork.LoadLevel("Battle");
    }
}


