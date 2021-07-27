using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitSpellButton : MonoBehaviour
{
    //inizializzare il bottone della spell

    public Spells spell;
    private float manaCost;
    public bool spellSelected = false;

    public float ManaCost { get => manaCost; }

    private void Start()
        {
        manaCost = spell.manaCost;
        GetComponent<Button>().onClick.AddListener(() => spellSelected = true);
        
        }
    }
