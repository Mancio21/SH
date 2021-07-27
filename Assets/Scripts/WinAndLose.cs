using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinAndLose : MonoBehaviour
{


    public UnityEvent winEvent;
    public UnityEvent loseEvent;

    private void Start()
        {
        CombatManager.Instance.playerWin += () => winEvent?.Invoke();
        CombatManager.Instance.playerLose += () => loseEvent?.Invoke();
        }

    public void Win()
        {
        Debug.Log("win");
        GameManager.Instance.LoadScene(GameManager.Instance.actualScene, true);
        }

    public void Lose()
        {
        Debug.Log("lose");
        GameManager.Instance.LoadScene(GameManager.Instance.checkpointScene);
        }

    }
