using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleLauncher : MonoBehaviour
{

    public string playername = "defaultplayer";

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
