using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaButton : MonoBehaviour {

    public GameObject Activated;
    public GameObject[] Deactivated = new GameObject[3];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangePanels()
    {
        Activated.SetActive(true);
        foreach (GameObject d in Deactivated)
        {
            d.SetActive(false);
        }
    }
}
