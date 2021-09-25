using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverStats : MonoBehaviour
{

    private Player player;

    private void Start()
        {
        player = GameManager.Instance.playerInCombat.GetComponent<Player>();
        }


    public void OnCollisionEnter2D(Collision2D collision)
        {
        Recover();
        }

    public void Recover()
        {
        GameManager.Instance.playerInfo.currentHP = player.stats.health;

        GameManager.Instance.playerInfo.currentMana = player.stats.mana;

        Debug.Log("recover");

        }

    }
