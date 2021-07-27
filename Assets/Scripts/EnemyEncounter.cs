using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEncounter : MonoBehaviour
{

    Transform player;
    private Vector3 framePos;
    [SerializeField] private int encounterPercentage = 25;
    public List<Enemy> enemiesPrefabs;
    public Vector2 percentages = new Vector2(70, 90);
    public float treshold;

    private void Awake()
        {
        player = FindObjectOfType<PlayerMovement>().transform;
        }
    private void Start()
        {

        GameManager.Instance.playerInOverworld = player;

        StartCoroutine(Encounter());
        }

    IEnumerator Encounter()
        {
        yield return null;

        while (true)
            {
            framePos = player.position;
            yield return new WaitUntil(() => Vector3.SqrMagnitude(player.position - framePos) > treshold);

                
                // calcola se avviene l'incontro
                var i = Random.Range(0, 101);

                if (i <= encounterPercentage)
                    {
                    SetUpBattle();
                    }
                }
            
        }

    private void SetUpBattle()
        {
        GameManager.Instance.playerInfo.currentPos = player.position;

        var i = Random.Range(0 , 101);

        if (i < percentages.x)
            {
            PopulateEnemies(1);
            }
        else if (i < percentages.y)
            {
            PopulateEnemies(2);
            }
        else
            {
            PopulateEnemies(3);
            }
        Time.timeScale = 0;
        GameManager.Instance.LoadScene("Combat scene", false, true);
        }

    public void PopulateEnemies(int enemyNumber)
        {
        GameManager.Instance.enemies.Clear();

        for (int i = 0; i < enemyNumber; i++)
            {
            var index = Random.Range(0, enemiesPrefabs.Count);
            GameManager.Instance.enemies.Add(enemiesPrefabs[index].gameObject);
            } 
        }

}
