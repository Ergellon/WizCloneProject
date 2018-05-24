using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Player playerone, playertwo;

    public bool firstplayeradded = false;
    public bool playersready = false;

    public BattleManager battleManager;
    public BattleUIManager battleuimanager;


    //public List<GameObject> playerslist = new List<GameObject>();

    void Awake()
    {
        PhotonNetwork.Instantiate("Player", new Vector3(0, 0, 0), Quaternion.identity, 0);
    }
    void Start ()
    {

    }
	
	void Update () {
        if (playersready == true)
        {
            Debug.Log("READY");

            battleManager.SetPlayerToBattleManager(playerone, playertwo);
            battleuimanager.SetPlayerToUIManager(playerone, playertwo);
            battleuimanager.SetNames();
            battleuimanager.SetSpellbook();
            //Debug.Log(playerone.playername);
            //Debug.Log(playertwo.playername);

            playerone.hasTurn = true;

            playersready = false;
        }                      
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }

    public void SetPlayer(Player p)
    {

        if (firstplayeradded == false)
        {
            firstplayeradded = true;
            playerone = p;
        }
        else
        {
            playertwo = p;
            playersready = true;
        }
    }

    public void ChangeTurn()
    {
        if (playerone.hasTurn)
        {
            playerone.hasTurn = false;
            playertwo.hasTurn = true;
            Debug.Log("Player 2 turn");
            
        }
        else
        {
            playertwo.hasTurn = false;
            playerone.hasTurn = true;
            Debug.Log("Player 1 turn");
        }
        
    }
}
