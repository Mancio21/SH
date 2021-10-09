using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootOnCollision : Loot
{
    public PotionScriptable potion;


    protected override void OnCollisionEnter2D(Collision2D collision)
        {
        base.OnCollisionEnter2D(collision);
        actualInteractButton.onClick.AddListener(delegate { InventoryLogic.CollectPotion(potion); });

        }

    }
