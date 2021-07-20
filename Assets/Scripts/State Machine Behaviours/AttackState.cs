using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    private Unit unit;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        if (unit == null)
            {
            unit = animator.GetComponent<Unit>();
            }
        unit.Attack(true, unit);
        }

    }
