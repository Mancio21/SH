using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loot : MonoBehaviour
{
    public static bool used = false;
    protected Button actualInteractButton;

    protected virtual void Awake()
        {
        if (used)
            {
            this.enabled = false;
            }
        }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
        actualInteractButton = InGameUI.Instance.interactButton;
        actualInteractButton.onClick.AddListener(Used);
        }

    protected void Used()
        {
        used = true;

        actualInteractButton.onClick.RemoveAllListeners();
        Debug.Log("used");
        this.enabled = false;

        }
    protected virtual void OnCollisionExit2D(Collision2D collision)
        {
        if (used || !actualInteractButton)
            {
            return;
            }
        actualInteractButton.onClick.RemoveAllListeners();
        }
    }
