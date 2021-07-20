using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    private bool playerTurn = false;
    private bool shieldActive = false;

    public override void PerformTurn()
        {
        base.PerformTurn();

        playerTurn = true;
        }

    public override void Attack(bool meleeAttack, Unit enemy)
        {
        if (meleeAttack)
            {
            enemy.Damaged(attack);
            }
        else
            {
            enemy.Damaged(magic);
            }
        }

    public void Shield()
        {
        shieldActive = true;
        }

    public override void Damaged(float damage)
        {
        if (shieldActive)
            {
            //animazione di parata
            health -= (damage / 2);
            }
        else
            {
            base.Damaged(damage);
            }
        }



}
