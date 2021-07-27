using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        animator.GetComponentInParent<Unit>().isDead = true;
        }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        //Destroy(animator.gameObject);
        
        animator.gameObject.SetActive(false);
        }

    }
