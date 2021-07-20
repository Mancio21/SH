using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "unitStats")] 
public class UnitStats : ScriptableObject
{
    public string unitName;
    public float health;
    public float mana;
    public float attack;
    public float magic;
    public float defense;
    public float magicDefense;
    public float speed;


}
