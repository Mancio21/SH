using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryLogic 
{

    public static int smallPotionCounter = 0;
    public static int mediumPotionCounter = 0;
    public static int largePotionCounter = 0;
    public static int smallManaCounter = 0;
    public static int mediumManaCounter = 0;
    public static int largeManaCounter = 0;

    public static bool hasAxe = false;
    public static bool hasPickaxe = false;
    public static void CollectPotion(PotionScriptable potion)
        {
        switch (potion.type)
            {
            case PotionType.health:
                CheckSize(potion, true, true);
                break;
            case PotionType.mana:
                CheckSize(potion, true, false);
                break;
            }
        }
    public static void UsePotion(PotionScriptable potion)
        {
        switch (potion.type)
            {
            case PotionType.health:
                GameManager.Instance.UpdateInfo(true, potion.recoverValue);
                CheckSize(potion, false, true);
                break;
            case PotionType.mana:
                GameManager.Instance.UpdateInfo(false, potion.recoverValue);

                CheckSize(potion, false, false);
                break;
            }
        }
    private static void CheckSize(PotionScriptable potion, bool add, bool health)
        {
        switch (potion.size)
            {
            case PotionSize.small:
                if (health)
                    {
                    AddRemovePotion(ref smallPotionCounter, add);
                    }
                else
                    {
                    AddRemovePotion(ref smallManaCounter, add);
                    }
                break;
            case PotionSize.medium:
                if (health)
                    {
                    AddRemovePotion(ref mediumPotionCounter, add);
                    }
                else
                    {
                    AddRemovePotion(ref mediumManaCounter, add);
                    }
                break;
            case PotionSize.large:
                if (health)
                    {
                    AddRemovePotion(ref largePotionCounter, add);
                    }
                else
                    {
                    AddRemovePotion(ref largeManaCounter, add);
                    }
                break;

            }
        }

    private static void AddRemovePotion(ref int counter, bool add)
        {
        if (add)
            {
            counter++;
            }
        else
            {
            counter--;
            }
        }


}
