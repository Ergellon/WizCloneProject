using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : Card {

    public bool firstturn;
    public Creature()
    {
        iscreature = true;
        firstturn = true;
    }
    public virtual void OnSpawn(Player attacker, Player defender, int slot)
    {

    }
    public virtual void OnAttack(Player attacker, Player defender, int slot)
    {
        if (defender.battlelinefilling[slot] == true)
        {
            defender.battleline[slot].health -= attacker.battleline[slot].attack;
        }
        else
        {
            defender.health -= attacker.battleline[slot].attack;          
        }
    }
    public virtual void OnDefence(Player attacker, Player defender, int slot)
    {

    }
    public virtual void OnDeath(Player attacker, Player defender, int slot)
    {

    }
}
