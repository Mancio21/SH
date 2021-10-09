using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{

    public Text nameText;
    public Text levelText;
    public Slider hpSlider;
    public Slider manaSlider;

    private Unit unit;

    private void Start()
        {
        
        }

    public void SetHUD(Unit unit)
        {
        if (levelText)
            {
            levelText.text = GameManager.Instance.playerInfo.lvl.ToString();
            }
        nameText.text = unit.UnitName;
        

        hpSlider.maxValue = unit.Health;
        hpSlider.value = unit.CurrentHealth;

        if (manaSlider)
            {
            manaSlider.maxValue = unit.Mana;
            manaSlider.value = unit.CurrentMana;
            }
        
        
        }

    public void SetHP(float hp)
        {
        hpSlider.value = hp;
        }
    public void SetMana(float mana)
        {
        manaSlider.value = mana;
        }

}
