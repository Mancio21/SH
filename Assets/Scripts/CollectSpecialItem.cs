using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSpecialItem : Loot
{
    public ItemConditions item;
    public Animator anim;

    protected override void Awake()
        {
        if (used)
            {
            //anim.SetTrigger
            }
        base.Awake();
        }

    protected override void OnCollisionEnter2D(Collision2D collision)
        {
        base.OnCollisionEnter2D(collision);
        actualInteractButton.onClick.AddListener(CollectItem);
        }

    private void CollectItem()
        {
        //anim.SetTrigger
        switch (item)
            {
            case ItemConditions.hasAxe:
                InventoryLogic.hasAxe = true;
                break;


            case ItemConditions.hasPickaxe:
                InventoryLogic.hasPickaxe = true;
                break;


            }
        }

    }
