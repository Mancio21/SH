using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Toggle volumeToggle;

    private void Start()
        {
        if(volumeToggle != null)
            {
            if(AudioListener.volume == 0)
                {
                volumeToggle.isOn = false;
                AudioListener.volume = 0;
                }
            }
        }
    public void Exit()
        {
        Application.Quit();
        }

    public void StartGame()
        {
        GameManager.Instance.LoadScene("Dungeon");
        }

    public void LoadScene(string sceneName)
        {
        GameManager.Instance.LoadScene(sceneName);
        }

    public void LoadPrevScene()
        {
        GameManager.Instance.LoadScene(GameManager.Instance.sceneBeforeMenu);
        }

    public void GoToMenu()
        {
        GameManager.Instance.sceneBeforeMenu = SceneManager.GetActiveScene().name;
        GameManager.Instance.LoadScene("Options");
        }

    public void MuteAudio()
        {
        if (AudioListener.volume == 0)
            {
            AudioListener.volume = 1;
            }
        else
            {
            AudioListener.volume = 0;
            }
        }

    public void SetTimeScale(int scale)
        {
        Time.timeScale = scale;
        }
    }
