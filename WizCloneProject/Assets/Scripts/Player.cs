using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public string name = "default";
    


	void Start () {
		
	}
	
	void Update () {
		
	}

    public void SetName(string n)
    {
        name = n;
    }
}
