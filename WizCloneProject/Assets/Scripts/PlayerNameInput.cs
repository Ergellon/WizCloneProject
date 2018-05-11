using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour {

    static string playerNamePrefKey = "player";

	void Start ()
    {
        string defaultname = "player";
        InputField inputfield = this.GetComponent<InputField>();
        if (inputfield !=null)
        {
            if(PlayerPrefs.HasKey(playerNamePrefKey))
            {
                defaultname = PlayerPrefs.GetString(playerNamePrefKey);
                inputfield.text = defaultname;
            }
        }

        PhotonNetwork.playerName = defaultname;
	}
	
	void Update ()
    {
		
	}

    public void SetPlayerName(string name)
    {
        PhotonNetwork.playerName = name + " ";
        PlayerPrefs.SetString(playerNamePrefKey, name);
    }
}
