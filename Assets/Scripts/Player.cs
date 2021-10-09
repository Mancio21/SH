using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Unit
{
    private bool shieldActive = false;
    public GameObject abilityButtons;

    public Dictionary<Button, InitSpellButton> dictionary = new Dictionary<Button, InitSpellButton>();

    protected override void Awake()
        {
        base.Awake();
        GameManager.Instance.lvlUP += delegate { UpdateStats(stats); };
        }


    public override void UpdateStats(UnitStats stats)
        {
        if (this == null)
            {
            return;
            }
        unitName = stats.unitName;
        maxHealth = stats.health + (GameManager.Instance.playerInfo.lvl * GameManager.Instance.gainValues.health);
        mana = stats.mana + (GameManager.Instance.playerInfo.lvl * GameManager.Instance.gainValues.mana);
        attack = stats.attack + (GameManager.Instance.playerInfo.lvl * GameManager.Instance.gainValues.attack);
        magic = stats.magic + (GameManager.Instance.playerInfo.lvl * GameManager.Instance.gainValues.magic);
        defense = stats.defense + (GameManager.Instance.playerInfo.lvl * GameManager.Instance.gainValues.defense);
        speed = stats.speed - (GameManager.Instance.playerInfo.lvl * GameManager.Instance.gainValues.speed);

        if (!GameManager.Instance.playerInfo.initializedHP)
            {
            GameManager.Instance.playerInfo.currentHP = maxHealth;
            GameManager.Instance.playerInfo.currentMana = mana;
            GameManager.Instance.playerInfo.maxHP = maxHealth;
            GameManager.Instance.playerInfo.maxMana = mana;
            currentHealth = maxHealth;
            currentMana = mana;

            GameManager.Instance.playerInfo.initializedHP = true;
            }
        else
            {
            currentHealth = GameManager.Instance.playerInfo.currentHP;
            currentMana = GameManager.Instance.playerInfo.currentMana;
            }

        IEnumerator WaitHUD()
            {
            yield return new WaitUntil(() => battleHUD);
            battleHUD.SetHUD(this);
            }
        if (battleHUD)
            {
            battleHUD.SetHUD(this);
            }
        else
            {
            StartCoroutine(WaitHUD());

            }


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
                
                abilityButtons.SetActive(true);

                CheckSpells();
                
            }
        StartCoroutine(WaitForTurn());
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

        string text = $"{unitName} use shield. It will prevent half damage from next attack.";

        CombatManager.Instance.WriteOnText(text);

        EndTurn();
        }

    public override void Damaged(float damage)
        {


        if (shieldActive)
            {
            //animazione di parata
            currentHealth -= (damage / 2);
            shieldActive = false;
            CombatManager.Instance.AddOnText(" But shield is active.");

            battleHUD.SetHP(currentHealth);
            if (currentHealth > 0)
                {
                anim.SetTrigger("Hitted");
                }
            else
                {
                CombatManager.Instance.AddOnText($" {unitName} is death.");
                StopAllCoroutines();

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
        if (!CombatManager.Instance.CheckBattleState())
            {
            finishPerforming = true;
            speedBar.Init(speed);
            PerformTurn();
            }


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
