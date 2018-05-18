using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Player playerone, playertwo;

    void Awake()
    {
        PhotonNetwork.Instantiate("Player", new Vector3(0, 0, 0), Quaternion.identity, 0);
    }
    void Start () {

    }
	
	void Update () {
		
	}
}
