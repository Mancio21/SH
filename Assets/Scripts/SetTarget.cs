using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTarget : MonoBehaviour
{
    public Button targetButton;
    Enemy enemy;

    private void Start()
        {
        CombatManager.Instance.needTarget += Target;
        CombatManager.Instance.targetChosen += TurnOffTarget;
        enemy = GetComponent<Enemy>();
        }

    public void Target(Animator player, string animTrigger)
        {
        if (enemy.isDead)
            {
            return;
            }
        targetButton.gameObject.SetActive(true);
        targetButton.onClick.AddListener(() => {
            CombatManager.Instance.currentTarget = enemy;

            player.SetTrigger(animTrigger);

            CombatManager.Instance.InvokeTargetChosen();
        });
        
        }

    public void TurnOffTarget()
        {
        targetButton.gameObject.SetActive(false);
        targetButton.onClick.RemoveAllListeners();
        }
}
