﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public BattleManager battleManager;
    public BattleUIManager battleUIManager;
    public Player playerone, playertwo;
    public Player localplayer;

    GameObject[] playerobjects = new GameObject[2];
    Player[] players = new Player[2];

    public Card selectedcard;


    PhotonView photonView;
    void Start()
    {

        photonView = PhotonView.Get(this);
        playerobjects = GameObject.FindGameObjectsWithTag("Player");
        if (playerobjects[0].GetComponent<Player>().photonView.viewID < playerobjects[1].GetComponent<Player>().photonView.viewID)
        {
            playerone = playerobjects[0].GetComponent<Player>();
            playertwo = playerobjects[1].GetComponent<Player>();
        }
        else
        {
            playerone = playerobjects[1].GetComponent<Player>();
            playertwo = playerobjects[0].GetComponent<Player>();
        }

        if (playerone.photonView.isMine)
        {
            localplayer = playerone;
            Debug.Log("local player one");
        }
        else if (playertwo.photonView.isMine)
        {
            localplayer = playertwo;
            Debug.Log("local player two");
        }

        players[0] = playerone; players[1] = playertwo;

        battleManager.SetPlayer(playerone, playertwo);
        battleUIManager.SetPlayer(playerone, playertwo);
        battleUIManager.SetNames();

        battleUIManager.UpdateStats();
        battleUIManager.SetSpellbookUI();


        playerone.hasturn = true;
        battleManager.attacker = playerone;
        battleManager.defender = playertwo;
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }

    public void SkipTurn()
    {
        if (localplayer.hasturn == true)
        {
            photonView.RPC("ChangeTurn", PhotonTargets.All);
            battleUIManager.UpdateStats();
        }
    }


    [PunRPC]
    public void ChangeTurn()
    {
        Debug.Log("Turn function started");
        battleManager.SwitchAttacker();
        for (int i = 0; i < 2; i++)
        {
            if (players[i].hasturn == true)
            {
                players[i].hasturn = false;
            }
            else
            {
                players[i].IncreaseMana();
                players[i].hasturn = true;
            }
        }
        battleUIManager.UpdateStats();
    }

    public void CardSelected(int n)
    {
<<<<<<< HEAD
        if (localplayer.hasturn == true)
        {
            photonView.RPC("SelectCard", PhotonTargets.All, n);
        }
    }
    [PunRPC]
    public void SelectCard(int n)
    {
        if (playerone.hasturn == true)
        {
            selectedcard = playerone.spellbook[n];
        }
        else
        {
            selectedcard = playertwo.spellbook[n];
        }
=======
        //selectedcard = localplayer.spellbook[n];
        photonView.RPC("SelectCard", PhotonTargets.All, n);
    }
    [PunRPC]
    public void SelectCard (int n)
    {
        selectedcard = localplayer.spellbook[n];
>>>>>>> f847588708c498d5c7b8ba48db1e79df18186c2f
    }

    public void CardPlaced(int slot)
    {

        if (localplayer.hasturn == true && selectedcard.iscreature == true
            && localplayer.battlelinefilling[slot] == false)
        {
            photonView.RPC("PlaceCard", PhotonTargets.All, slot);
<<<<<<< HEAD
            photonView.RPC("AttackSequence", PhotonTargets.All);
            AttackSequence();
=======
>>>>>>> f847588708c498d5c7b8ba48db1e79df18186c2f
            photonView.RPC("ChangeTurn", PhotonTargets.All);
        }
    }

    [PunRPC]
    public void PlaceCard(int slot)
    {
        battleManager.PlaceCard((Creature)selectedcard, slot);
        battleUIManager.UpdateBattleline();
    }
    public void SpellUsed(int slot)
    {
        if(localplayer.hasturn == true && selectedcard.iscreature == false)
        {
            photonView.RPC("UseSpell", PhotonTargets.All, slot);
        }
    }
    [PunRPC]
    public void UseSpell (int slot)
    {
<<<<<<< HEAD
        battleManager.UseSpell(slot);
        battleUIManager.UpdateBattleline();
    }
    [PunRPC]
    public void AttackSequence()
    {
        battleManager.AttackSequence(localplayer);
=======
        battleManager.UseSpell((Spell)selectedcard, slot);
        battleUIManager.UpdateBattleline();
>>>>>>> f847588708c498d5c7b8ba48db1e79df18186c2f
    }
}
