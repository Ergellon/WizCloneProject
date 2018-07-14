using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManaButton : MonoBehaviour {


    public GameObject activated;
    public GameObject[] deactivated = new GameObject[3];
 	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UseButton()
    {
        activated.SetActive(true);
        for (int i = 0; i<3; i++)
        {
            deactivated[i].SetActive(false);
        }
    }
}
