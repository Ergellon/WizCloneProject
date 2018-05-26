using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Player playerone, playertwo;

    public bool firstplayeradded = false;
    public bool playersready = false;

    public BattleManager battleManager;
    public BattleUIManager battleuimanager;

    public Creature selectedcard;

    //public List<GameObject> playerslist = new List<GameObject>();

    void Awake()
    {
        PhotonNetwork.Instantiate("Player", new Vector3(0, 0, 0), Quaternion.identity, 0);
    }
    void Start()
    {

    }

    void Update()
    {
        if (playersready == true)
        {
            //battleManager.SetPlayerToBattleManager(playerone, playertwo);
            battleuimanager.SetPlayerToUIManager(playerone, playertwo);
            battleuimanager.SetNames();
            battleuimanager.SetSpellbook();
            //Debug.Log(playerone.playername);
            //Debug.Log(playertwo.playername);

            playerone.hasTurn = true;
            Debug.Log("Player 1 turn");
            playerone.fire++; playerone.water++; playerone.earth++; playerone.air++;

            playersready = false;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }

    public void SetPlayer(Player p)
    {

        if (firstplayeradded == false)
        {
            firstplayeradded = true;
            playerone = p;
        }
        else
        {
            playertwo = p;
            playersready = true;
        }
    }


    public void ChangeTurn()
    {
        if (playerone.hasTurn)
        {
            playerone.hasTurn = false;
            playertwo.hasTurn = true;
            playertwo.fire++; playertwo.water++; playertwo.earth++; playertwo.air++;
            Debug.Log("Player 2 turn");

        }
        else
        {
            playertwo.hasTurn = false;
            playerone.hasTurn = true;
            playerone.fire++; playerone.water++; playerone.earth++; playerone.air++;

            Debug.Log("Player 1 turn");
        }

    }
    public void SelectedCard(Button b)
    {
        for (int i = 0; i < 24; i++)
        {
          
            if (b == battleuimanager.spellbook[i] && playerone.hasTurn)
            {
                selectedcard = playerone.spellbook[i];

            }
            if (b == battleuimanager.spellbook[i] && playertwo.hasTurn)
            {
                selectedcard = playertwo.spellbook[i];
            }
        }

    }
    public void PlaceCard(Button b)
    {
        int n = 1;
        bool turndone = false;
        for (int i = 0; i<7;i++)
        {
            if (b==battleuimanager.playercreatures[i] && playerone.hasTurn && (playerone.creatures[i].isempty == true))
            {
                playerone.creatures[i] = selectedcard;
                n = i;
                turndone = true;
            }
            else if (b == battleuimanager.playercreatures[i] &&playertwo.hasTurn && (playertwo.creatures[i].isempty == true))
            {
                playertwo.creatures[i] = selectedcard;
                n = i;
                turndone = true;
            }
        }
        if (turndone == true)
        {
            battleuimanager.PlaceCreature(n, selectedcard);

            //Fighting();
            ChangeTurn();
        }

    }
    public void Fighting()
    {

    }
}
