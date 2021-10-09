using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemConditions
    {
    hasAxe, hasPickaxe
    }
public class DestroyWithCondition : Loot
{

    public ItemConditions condition;

    protected override void Awake()
        {
        if (used)
            {
            gameObject.SetActive(false);
            enabled = false;
            }
        }
    protected override void OnCollisionEnter2D(Collision2D collision)
        {
        if (!CheckCondition())
            {
            return;
            }
        base.OnCollisionEnter2D(collision);
        actualInteractButton.onClick.AddListener(DestroyObject);
        }

    private bool CheckCondition()
        {
        switch (condition)
            {
            case ItemConditions.hasAxe:
                if (InventoryLogic.hasAxe)
                    {
                    return true;
                    }
                else
                    {
                    return false;
                    }

            case ItemConditions.hasPickaxe:
                if (InventoryLogic.hasPickaxe)
                    {
                    return true;
                    }
                else
                    {
                    return false;
                    }

            }
        return false;
        }

    private void DestroyObject()
        {
        gameObject.SetActive(false);
        }

    }
