using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatManager : Singleton<CombatManager>
{
    public GameObject player;
    public List<GameObject> enemies;
    public Vector3 playerPos;
    public List<Vector3> enemiesPos;

    public List<Unit> battleQueue;

    private bool goOn = false;

    private void Start()
        {
        DontDestroyOnLoad(this);
        Init();
        }

    public void Init()
        {
        List<Unit> battleQueueTemp = new List<Unit>();
        battleQueueTemp.Add(Instantiate(player, playerPos, Quaternion.identity).GetComponent<Unit>());

        

        for (int i = 0; i < enemies.Count; i++)
            {
            GameObject enemyGO = Instantiate(enemies[i], enemiesPos[i], Quaternion.identity);
            battleQueueTemp.Add(enemyGO.GetComponent<Unit>());
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
                    unit.PerformTurn();
                    yield return new WaitUntil(() => goOn);

                    yield return new WaitForSeconds(1);
                    }
                }
            }
        StartCoroutine(COTurnManager());
        }

    public void CheckBattleState()
        {
        goOn = true;
        }
    }
