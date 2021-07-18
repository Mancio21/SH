using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEncounter : MonoBehaviour
{

    Transform player;
    [SerializeField] private float cooldownMax;
    private Vector3 framePos;

    private void Awake()
        {
        player = FindObjectOfType<PlayerMovement>().transform;
        }
    private void Start()
        {
        StartCoroutine(Encounter());
        }

    IEnumerator Encounter()
        {
        while (true)
            {
            framePos = player.position;
            yield return new WaitForSeconds(cooldownMax);
            if (framePos != player.position)
                {
                // calcola se avviene l'incontro

                }
            }
        }
    void Update()
    {
        
    }
}
