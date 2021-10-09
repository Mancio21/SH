using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{

    private void Awake()
        {
        Debug.Log(SceneManager.GetActiveScene().name);

        GameManager.Instance.checkpointScene = SceneManager.GetActiveScene().name;
        }
    }
