using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGraphic : MonoBehaviour
{
    public PotionButton[] potionButtons;

    [Serializable]
    public struct PotionButton
        {
        public PotionScriptable potion;
        public Text potionCounterText;
        public int potionCounter;
        public Button potionUIButton;
        }

    private void OnEnable()
        {
        potionButtons[0].potionCounter = InventoryLogic.smallPotionCounter;
        potionButtons[1].potionCounter = InventoryLogic.mediumPotionCounter;
        potionButtons[2].potionCounter = InventoryLogic.largePotionCounter;
        potionButtons[3].potionCounter = InventoryLogic.smallManaCounter;
        potionButtons[4].potionCounter = InventoryLogic.mediumManaCounter;
        potionButtons[5].potionCounter = InventoryLogic.largeManaCounter;

        foreach (var button in potionButtons)
            {
            button.potionCounterText.text = button.potionCounter.ToString();
            if (button.potionCounter == 0)
                {
                button.potionUIButton.enabled = false;
                }
            else if (button.potion.type == PotionType.health)
                {
                if (GameManager.Instance.playerInfo.currentHP == GameManager.Instance.playerInfo.maxHP)
                    button.potionUIButton.enabled = false;
                }
            else if (button.potion.type == PotionType.mana)
                {
                if (GameManager.Instance.playerInfo.currentMana == GameManager.Instance.playerInfo.maxMana)
                    button.potionUIButton.enabled = false;
                }

            else
                {
                button.potionUIButton.enabled = true;

                }
            }
        }

    public void UsePotion(int index)
        {
        ref PotionButton button = ref potionButtons[index];
        InventoryLogic.UsePotion(button.potion);
        button.potionCounter--;
        button.potionCounterText.text = button.potionCounter.ToString();

        if (button.potionCounter == 0)
            {
            button.potionUIButton.enabled = false;
            }
        else if (button.potion.type == PotionType.health)
            {
            if (GameManager.Instance.playerInfo.currentHP == GameManager.Instance.playerInfo.maxHP)
                button.potionUIButton.enabled = false;
            }
        else if (button.potion.type == PotionType.mana)
            {
            if (GameManager.Instance.playerInfo.currentMana == GameManager.Instance.playerInfo.maxMana)
                button.potionUIButton.enabled = false;
            }
        }
}
