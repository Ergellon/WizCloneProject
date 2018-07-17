using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    public BattleUIManager battleUIManager;

    Player playerone, playertwo;

    public Player attacker, defender;

	void Start ()
    {

	}
	
	void Update ()
    {
		
	}

    public void SetPlayer (Player pone, Player ptwo)
    {
        playerone = pone;
        playertwo = ptwo;
    }
    public void SwitchAttacker()
    {
        Player p = attacker;
        attacker = defender;
        defender = p;
    }
    public void PlaceCard(Creature creature,int slot)
    {
        attacker.battleline[slot] = creature;
    }
    public void UseSpell (Spell spell, int slot)
    {

    }
    
}
