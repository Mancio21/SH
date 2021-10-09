using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PotionType
    {
    health, mana
    }
public enum PotionSize
    {
    small, medium, large
    }

[CreateAssetMenu(fileName = "potion", menuName = "potion scriptable")]
public class PotionScriptable : ScriptableObject
{

    public string potionName;
    public Sprite sprite;
    public PotionType type;
    public PotionSize size;
    public float recoverValue;
}
