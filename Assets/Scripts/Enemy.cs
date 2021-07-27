using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{

    public override void UpdateStats(UnitStats stats)
        {
        base.UpdateStats(stats);

        currentHealth = Health;
        }
    public override void PerformTurn()
        {
        if (isDead)
            {
            base.PerformTurn();

            return;
            }

        

        CombatManager.Instance.currentTarget = CombatManager.Instance.currentPlayer;

        anim.SetTrigger("Melee");
        }

    public override void EndTurn()
        {

        CombatManager.Instance.CheckBattleState();
        }
    }


