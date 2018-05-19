using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Player playerone, playertwo;

    public BattleManager battleManager;


    public List<GameObject> playerslist = new List<GameObject>();

    void Awake()
    {
        playerslist.Add(PhotonNetwork.Instantiate("Player", new Vector3(0, 0, 0), Quaternion.identity, 0));
    }
    void Start ()
    {

    }
	
	void Update () {

	}

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
