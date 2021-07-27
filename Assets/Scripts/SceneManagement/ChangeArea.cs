using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeArea : MonoBehaviour
{

    public string sceneName;


    private void OnTriggerEnter2D(Collider2D collision)
        {
        GameManager.Instance.LoadScene(sceneName);
        }
    }
