using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicState : StateMachineBehaviour
    {
    private Unit unit;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        if (unit == null)
            {
            unit = animator.GetComponentInParent<Unit>();
            }
        unit.Magic(CombatManager.Instance.currentTarget);

        unit.EndTurn();
        }

    }