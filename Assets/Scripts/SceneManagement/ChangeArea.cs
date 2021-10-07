using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeArea : MonoBehaviour
{

    public string sceneName;
    public SpawnSide side;

    private void OnTriggerEnter2D(Collider2D collision)
        {
        GameManager.Instance.actualSide = side;
        GameManager.Instance.LoadScene(sceneName);
        }
    }
