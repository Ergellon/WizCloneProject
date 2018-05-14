using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleLauncher : Photon.MonoBehaviour {

    public string playername = "defaultplayer";
    public string enemyname = "defaultenemy";

    public InputField inputname;

	void Start () {

        DontDestroyOnLoad(this.gameObject);
	}
	
	void Update () {
		
	}

    public void ChangePlayerName()
    {      
            playername = inputname.text;       
    }
}
