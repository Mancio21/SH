using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitStats stats;
    protected string unitName;
    protected float health;
    protected float mana;
    protected float attack;
    protected float magic;
    protected float defense;
    protected float magicDefense;
    protected float speed;
    protected Animator anim;

    public float Speed { get => speed; }

    private void Awake()
        {
        UpdateStats(stats);
        anim = GetComponent<Animator>();
        }

    public void UpdateStats(UnitStats stats)
        {
        health += stats.health;
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
        CombatManager.Instance.CheckBattleState();
        }

    public virtual void Damaged(float damage)
        {
        health -= damage;
        }


    public virtual void Attack(bool meleeAttack, Unit unit)
        {

        }
    }
