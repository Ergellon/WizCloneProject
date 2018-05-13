using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleLauncher : Photon.MonoBehaviour {

    public string playername = "defaultplayer";
    public string enemyname = "defaultenemy";

    public InputField inputname;

	void Start () {

        DontDestroyOnLoad(this);
	}
	
	void Update () {
		
	}

    public void ChangePlayerName()
    {
        if (photonView.isMine == true)
        {
            playername = inputname.text;
        }
        else
        {
            enemyname = inputname.text;
        }
    }
}
