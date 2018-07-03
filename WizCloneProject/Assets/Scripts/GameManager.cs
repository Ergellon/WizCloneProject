using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public BattleManager battleManager;
    public BattleUIManager battleUIManager;
    public Player playerone, playertwo;

    public int init = 0;

    GameObject[] playerobjects = new GameObject[2];
    
    void Start ()
    {
        PhotonNetwork.Instantiate("Player", new Vector3(0, 0, 0), Quaternion.identity, 0);
        while (init < 2);
        playerobjects = GameObject.FindGameObjectsWithTag("Player");
        playerone = playerobjects[0].GetComponent<Player>();
        playertwo = playerobjects[1].GetComponent<Player>();
    }
	
	void Update ()
    {
		
	}
}
