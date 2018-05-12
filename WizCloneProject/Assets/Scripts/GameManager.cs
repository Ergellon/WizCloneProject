using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Photon.PunBehaviour
{
    public static GameManager gameManager;

    // Use this for initialization
    void Start()
    {
        gameManager = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);

    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    void LoadArena()
    {
        if (!PhotonNetwork.isMasterClient)
        {
            Debug.LogError("not master client");
        }
        PhotonNetwork.LoadLevel("Battle");
    }

    public override void OnPhotonPlayerConnected(PhotonPlayer other)
    {
        Debug.Log(other.NickName);
        if (PhotonNetwork.isMasterClient)
        {
            Debug.Log("massster");
            LoadArena();
        }
    }
    public override void OnPhotonPlayerDisconnected(PhotonPlayer other)
    {
        Debug.Log(other.NickName + "left");
        if (PhotonNetwork.isMasterClient)
        {
            Debug.Log("massster left");
        }
    }

}
