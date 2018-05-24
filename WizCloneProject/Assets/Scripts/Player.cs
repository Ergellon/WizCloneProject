using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Photon.MonoBehaviour, IPunObservable {

    public string playername = "nonameloaded";

    public int health = 30;
    public int fire = 0, water = 0, earth = 0, air = 0;

    public bool hasTurn = false;

    public GameManager gamemanager;
    public GameObject gamemanagerobject;
    public GameObject battlemanager;
    public BattleLauncher battlelauncher;

    public List<Creature> spellbook = new List<Creature>();   // MUST BE CARD, NOT CREATURES

    public List<Creature> creatures = new List<Creature>();

    void Start ()
    {

    }

    void Update () {
		
	}

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(playername);
            stream.SendNext(health);
            stream.SendNext(fire); stream.SendNext(water);
            stream.SendNext(earth); stream.SendNext(air);
        }
        else
        {
            this.playername = (string)stream.ReceiveNext();
            this.health = (int)stream.ReceiveNext();
            this.fire = (int)stream.ReceiveNext();
            this.water = (int)stream.ReceiveNext();
            this.air = (int)stream.ReceiveNext();
            this.earth = (int)stream.ReceiveNext();
        }
        
    }

    void OnPhotonInstantiate (PhotonMessageInfo info)
    {
        //battlelauncher = GameObject.FindGameObjectWithTag("BattleLauncher").GetComponent<BattleLauncher>();
        //playername = battlelauncher.playername;
        //Debug.Log(playername);
        gamemanagerobject = GameObject.FindGameObjectWithTag("GameManager");
        gamemanager = gamemanagerobject.GetComponent<GameManager>();
        if (photonView.isMine)
        {
            battlelauncher = GameObject.FindGameObjectWithTag("BattleLauncher").GetComponent<BattleLauncher>();
            playername = battlelauncher.playername;

            FillSpellbook();

        }
        gamemanager.SetPlayer(this);
    }


    void FillSpellbook()
    {
        spellbook.Add(new Chicken());
        spellbook.Add(new Cow());

    }

}
