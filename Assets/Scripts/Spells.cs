using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpellType
    {
    Ice,
    Fire,
    Water
    }

[CreateAssetMenu(fileName = "Spell", menuName = "Spells")] 
public class Spells : ScriptableObject
{

    public string spellName;
    public Sprite spellSprite;
    public SpellType spellType;
    public float manaCost;
    
}
