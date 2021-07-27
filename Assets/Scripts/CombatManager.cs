using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatManager : Singleton<CombatManager>
{
    public Vector3 playerPos;
    public List<Vector3> enemiesPos;

    public List<Unit> battleQueue;

    private bool goOn = false;

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




    private void Start()
        {
        Init();
        }

    public void Init()
        {
        currentEnemies = new List<Enemy>();
        battleQueue = new List<Unit>();

        List<Unit> battleQueueTemp = new List<Unit>();
        currentPlayer = Instantiate(GameManager.Instance.playerInCombat, playerPos, Quaternion.identity).GetComponent<Unit>() as Player;
        battleQueueTemp.Add(currentPlayer);


        var enemies = GameManager.Instance.enemies;

        for (int i = 0; i < enemies.Count; i++)
            {
            GameObject enemyGO = Instantiate(enemies[i], enemiesPos[i], Quaternion.identity);

            Unit enemy = enemyGO.GetComponent<Unit>();
            battleQueueTemp.Add(enemy);

            currentEnemies.Add(enemy as Enemy);
            }

        battleQueue = battleQueueTemp.OrderByDescending(unit => unit.Speed).ToList();

        TurnManager();
        }

    public void TurnManager()
        {
        IEnumerator COTurnManager()
            {
            yield return null;

            while (true)
                {
                foreach (var unit in battleQueue)
                    {

                    yield return null;    
                        unit.PerformTurn();
                        yield return new WaitUntil(() => goOn);

                        yield return new WaitForSeconds(1);

                        goOn = false;
                        
                    }
                }
            }
        StartCoroutine(COTurnManager());
        }

    public void CheckBattleState()
        {
        if (currentPlayer.isDead)
            {
            playerLose?.Invoke();

            return;
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

                return;
                }
            }

        goOn = true;


        }

    public void InvokeTargetChosen()
        {
        targetChosen?.Invoke();
        }

    public void InvokeNeedTarget(Animator player, string animTrigger)
        {
        needTarget?.Invoke(player, animTrigger);
        }

    }
