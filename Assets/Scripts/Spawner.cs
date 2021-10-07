using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject player;
    public Transform upSpawner;
    public Transform bottomSpawner;
    public Transform rightSpawner;
    public Transform leftSpawner;

    void Awake()
        {
        switch (GameManager.Instance.actualSide)
            {
            case SpawnSide.up:
                InstantiatePlayer(upSpawner);

                break;

            case SpawnSide.bottom:
                InstantiatePlayer(bottomSpawner);

                break;

            case SpawnSide.left:
                InstantiatePlayer(leftSpawner);

                break;

            case SpawnSide.right:
                InstantiatePlayer(rightSpawner);

                break;
            }
        }

    private void InstantiatePlayer(Transform spawner)
        {
        Instantiate(player.gameObject, spawner.position, spawner.rotation);
        }
}
