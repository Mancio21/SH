using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{

    private void Start()
        {
        foreach (var button in GetComponentsInChildren<Button>())
            {
            button.onClick.AddListener(() => gameObject.SetActive(false));
            }
        }
    }
