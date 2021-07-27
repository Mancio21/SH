using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitStats stats;
    protected string unitName;
    protected float maxHealth;
    protected float mana;
    protected float attack;
    protected float magic;
    protected float defense;
    protected float magicDefense;
    protected float speed;
    protected Animator anim;
    protected float currentHealth;
    protected float currentMana;

    public float Speed { get => speed; }
    public string UnitName { get => unitName; }
    public float Health { get => maxHealth; }
    public float Mana { get => mana; }

    public float CurrentHealth { get => currentHealth; }
    public float CurrentMana { get => currentMana; }


    protected BattleHUD battleHUD;

    public bool isDead = false;

    private void Awake()
        {
        UpdateStats(stats);
        anim = GetComponentInChildren<Animator>();
        battleHUD = GetComponentInChildren<BattleHUD>();
        battleHUD.SetHUD(this);
        }

    public virtual void UpdateStats(UnitStats stats)
        {
        unitName = stats.unitName;
        maxHealth += stats.health;
        mana += stats.mana;
        attack += stats.attack;
        magic += stats.magic;
        defense += stats.defense;
        magicDefense += stats.magicDefense;
        speed += stats.speed;

        }

    public virtual void PerformTurn()
        {
        Debug.Log(this.name + " perform");
        //CombatManager.Instance.CheckBattleState();
        EndTurn();
        }

    public virtual void Damaged(float damage)
        {
        
        currentHealth -= damage;
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


    public virtual void MeleeAttack(Unit enemy)
        {
        enemy.Damaged(attack);
        


        }

    public virtual void Magic(Unit enemy)
        {
        enemy.Damaged(magic);
       


        }

    public virtual void EndTurn()
        {

        }
    }
