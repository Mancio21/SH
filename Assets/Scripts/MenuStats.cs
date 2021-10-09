using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStats : MonoBehaviour
{

    public Text hp;
    public Text mana;
    public Text exp;


    private void OnEnable()
        {
        var info = GameManager.Instance.playerInfo;
        hp.text = $"HP: {info.currentHP}/{info.maxHP}";
        mana.text = $"MANA: {info.currentMana}/{info.maxMana}";
        exp.text = $"EXP: {info.exp}/{info.expToNextLvl}";
        }
    }
