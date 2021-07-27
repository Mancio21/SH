using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Unit
{
    private bool shieldActive = false;
    public GameObject abilityButtons;

    public Dictionary<Button, InitSpellButton> dictionary = new Dictionary<Button, InitSpellButton>();

    public override void UpdateStats(UnitStats stats)
        {
        base.UpdateStats(stats);
        
        if (!GameManager.Instance.playerInfo.initializedHP)
            {
            GameManager.Instance.playerInfo.currentHP = maxHealth;
            GameManager.Instance.playerInfo.currentMana = mana;
            currentHealth = maxHealth;
            currentMana = mana;

            GameManager.Instance.playerInfo.initializedHP = true;
            }
        else
            {
            currentHealth = GameManager.Instance.playerInfo.currentHP;
            currentMana = GameManager.Instance.playerInfo.currentMana;
            }


        }
    public override void PerformTurn()
        {
        if (isDead)
            {
            base.PerformTurn();

            return;
            }


        abilityButtons.SetActive(true);

        CheckSpells();
        }


    public override void Magic(Unit enemy)
        {

        foreach (var spell in dictionary)
            {
            if (spell.Value.spellSelected)
                {
                currentMana -= spell.Value.ManaCost;
                spell.Value.spellSelected = false;
                break;
                }
            }

        battleHUD.SetMana(currentMana);
        GameManager.Instance.playerInfo.currentMana = currentMana;
        base.Magic(enemy);
            

        }
    public void Shield()
        {
        shieldActive = true;

        EndTurn();
        }

    public override void Damaged(float damage)
        {


        if (shieldActive)
            {
            //animazione di parata
            currentHealth -= (damage / 2);

            battleHUD.SetHP(currentHealth);
            if (currentHealth > 0)
                {
                anim.SetTrigger("Hitted");
                }
            else
                {
                anim.SetTrigger("Death");
                }
            }
        else
            {
            base.Damaged(damage);
            }

        GameManager.Instance.playerInfo.currentHP = currentHealth;
        }

    public void AttackWithTarget(string animTrigger)
        {
        CombatManager.Instance.InvokeNeedTarget(anim, animTrigger);
        }

    public override void EndTurn()
        {
        CombatManager.Instance.CheckBattleState();

        abilityButtons.SetActive(false);
        }

    private void CheckSpells()
        {
        if (dictionary.Count == 0)
            {

            foreach (var spell in abilityButtons.GetComponentsInChildren<InitSpellButton>())
                {
                dictionary.Add(spell.GetComponent<Button>(), spell);
                }
            }

        foreach (var spell in dictionary)
            {
            if (currentMana - spell.Value.ManaCost < 0)
                {
                spell.Key.interactable = false;
                }
            else
                {
                spell.Key.interactable = true;
                }
            }
        }

    public void Escape()
        {
        GameManager.Instance.LoadScene(GameManager.Instance.actualScene, true);
        }

    }
