using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Photon.MonoBehaviour, IPunObservable {

    public string playername = "defaultplayer_nonameloaded";


    void Start () {
		
	}
	
	void Update () {
		
	}

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
    }

    void OnPhotonInstantiate (PhotonMessageInfo info)
    {

    }


}
