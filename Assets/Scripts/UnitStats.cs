using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    public float Health;
    public float Mana;
    public float Attack;
    public float Magic;
    public float Defense;
    public float MagicDefense;
    public float Speed;

    public UnitStats(float healt, float mana, float attack, float magic, float defense, float magicDefense, float speed)
        {
        Health = healt;
        Mana = mana;
        Attack = attack;
        Magic = magic;
        Defense = defense;
        MagicDefense = magicDefense;
        Speed = speed;
        
        }
}
