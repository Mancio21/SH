using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    private int actualTimeScale;

    public GameObject[] panelList;
    void Start()
    {
        actualTimeScale = 1;
    }

    void Update()
    {
        
    }

    public void OpenCloseMenu(GameObject menuPanel)
        {
        menuPanel.SetActive(!menuPanel.activeInHierarchy);

        if (menuPanel.activeInHierarchy)
            {
            Time.timeScale = 0;
            }
        else
            {
            Time.timeScale = actualTimeScale;
            }
        }

    public void PanelOC(GameObject panel)
        {
        CloseCurrentPanel();
        panel.SetActive(!panel.activeSelf);
        }

    public void CloseCurrentPanel()
        {
        for (int i = 0; i < panelList.Length; ++i)
            {
            if (panelList[i].activeSelf)
                {
                panelList[i].SetActive(false);
                }
            }
        }

    public void SetTimeScale(int scale)
        {
        Time.timeScale = scale;
        actualTimeScale = scale;
        }

    }
