using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Player playerone, playertwo;

    public BattleManager battleManager;

    private GameObject[] playerslist;

    void Awake()
    {
        PhotonNetwork.Instantiate("Player", new Vector3(0, 0, 0), Quaternion.identity, 0);
    }
    void Start ()
    {
        playerslist = GameObject.FindGameObjectsWithTag("Player");

        int i = 0;
        foreach (GameObject p in playerslist)
        {
            i++;
            Debug.Log(i);
        }

        //playerone = playerslist[0].GetComponent<Player>();
        //playertwo = playerslist[1].GetComponent<Player>();

       /* if (playerone.photonView.isMine)
        {
            battleManager.SetPlayers(playerone, playertwo);
        }
        else
        {
            battleManager.SetPlayers(playertwo, playerone);
        }
        */



    }
	
	void Update () {
		
	}
}
