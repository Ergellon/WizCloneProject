using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public BattleManager battleManager;
    public BattleUIManager battleUIManager;
    public Player playerone, playertwo;


    public int activeplayernumber;

    GameObject[] playerobjects = new GameObject[2];
    Player[] players = new Player[2];


    PhotonView photonView;
    void Start ()
    {

        photonView = PhotonView.Get(this);
        playerobjects = GameObject.FindGameObjectsWithTag("Player");
        if (playerobjects[0].GetComponent<Player>().photonView.viewID< playerobjects[1].GetComponent<Player>().photonView.viewID)
        {
            playerone = playerobjects[0].GetComponent<Player>();
            playertwo = playerobjects[1].GetComponent<Player>();
        }
        else
        {
            playerone = playerobjects[1].GetComponent<Player>();
            playertwo = playerobjects[0].GetComponent<Player>();
        }
        
        players[0] = playerone; players[1] = playertwo;

        battleManager.SetPlayer(playerone, playertwo);
        battleUIManager.SetPlayer(playerone, playertwo);
        battleUIManager.SetNames();

        activeplayernumber = 0;

        battleUIManager.UpdateStats();
    }

	
	void Update ()
    {
        battleUIManager.UpdateStats();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(activeplayernumber);
        }
        else
        {
            activeplayernumber = (int)stream.ReceiveNext();
        }
    }

    public void ChangeTurn()
    {
        activeplayernumber++;
        activeplayernumber %= 2;
        players[activeplayernumber].IncreaseMana();
        battleUIManager.UpdateStats();
    }

    public void SkipTurn()
    {
            ChangeTurn();
    }
}
