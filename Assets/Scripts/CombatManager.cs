using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : Singleton<CombatManager>
{
    public Vector3 playerPos;
    public List<Vector3> enemiesPos;

    public List<Unit> battleQueue;

    public delegate void NeedTarget(Animator player, string animTrigger);
    public event NeedTarget needTarget;
    public delegate void TargetChosen();
    public event TargetChosen targetChosen;

    public delegate void PlayerWin();
    public event PlayerWin playerWin;

    public delegate void PlayerLose();
    public event PlayerLose playerLose;

    public Unit currentTarget;

    public Player currentPlayer;
    public List<Enemy> currentEnemies;

    public GameObject textBoxObj;
    private Text textBox;

    private bool combatFinished = false;


    private void Start()
        {
        Init();

        textBox = textBoxObj.GetComponentInChildren<Text>();
        textBoxObj.SetActive(false);
        }

    public void Init()
        {
        currentEnemies = new List<Enemy>();

        battleQueue = new List<Unit>();
        currentPlayer = Instantiate(GameManager.Instance.playerInCombat, playerPos, Quaternion.identity).GetComponent<Unit>() as Player;
        battleQueue.Add(currentPlayer);


        var enemies = GameManager.Instance.enemies;

        for (int i = 0; i < enemies.Count; i++)
            {
            GameObject enemyGO = Instantiate(enemies[i], enemiesPos[i], Quaternion.identity);

            Unit enemy = enemyGO.GetComponent<Unit>();
            battleQueue.Add(enemy);

            currentEnemies.Add(enemy as Enemy);
            }

        IEnumerator StartBattle()
            {
            yield return null;
            foreach (var unit in battleQueue)
                {
                unit.PerformTurn();
                }

            }
        StartCoroutine(StartBattle());
        }

    public bool CheckBattleState()
        {
        if (combatFinished)
            {
            return true;
            }
        if (currentPlayer.isDead)
            {
            GameManager.Instance.SetPlayerInfoAfterDeath();

            playerLose?.Invoke();
            DisableBars();
            combatFinished = true;
            return true;
            }

        else
            {
            bool allDeath = true;

            foreach (var enemy in currentEnemies)
                {
                if (!enemy.isDead)
                    {
                    allDeath = false;
                    }
                }

            if (allDeath)
                {
                playerWin?.Invoke();
                DisableBars();
                combatFinished = true;
                return true;
                }
            }

        return false;
        }

    public void InvokeTargetChosen()
        {
        targetChosen?.Invoke();
        }

    public void InvokeNeedTarget(Animator player, string animTrigger)
        {
        needTarget?.Invoke(player, animTrigger);
        }

    public void WriteOnText(string text)
        {
        textBox.text = text;
        textBoxObj.SetActive(true);
        }

    public void AddOnText(string text)
        {
        IEnumerator SkipFrame()
            {
            yield return null;

            textBox.text += text;
            }
        StartCoroutine(SkipFrame());
        
        }

    public void DisableBars()
        {
        foreach (var unit in battleQueue)
            {
            unit.speedBar.FinishBattle();
            unit.StopAllCoroutines();
            }
        }
    }
