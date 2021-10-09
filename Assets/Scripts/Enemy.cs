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

        IEnumerator WaitForTurn()
            {
                yield return new WaitUntil(() => finishPerforming);

                finishPerforming = false;

                yield return new WaitForSeconds(speed);

                CombatManager.Instance.currentTarget = CombatManager.Instance.currentPlayer;

                anim.SetTrigger("Melee");
                
            }
        StartCoroutine(WaitForTurn());
        }

    public override void Damaged(float damage)
        {

        currentHealth -= damage;
        battleHUD.SetHP(currentHealth);
        if (currentHealth > 0)
            {
            anim.SetTrigger("Hitted");
            }
        else
            {
            CombatManager.Instance.AddOnText($" {unitName} is death.");

            StopAllCoroutines();

            speedBar.FinishBattle();
            GameManager.Instance.GainExp(stats.exp, this);
            anim.SetTrigger("Death");

            }
        }
    public override void EndTurn()
        {
        if (!CombatManager.Instance.CheckBattleState())
            {
            finishPerforming = true;
            speedBar.Init(speed);
            PerformTurn();
            }

        }
    }


