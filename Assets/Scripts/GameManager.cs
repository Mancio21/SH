

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SpawnSide
    {
    left, right, up, bottom
    }
public class GameManager : Singleton<GameManager>
    {
    public PlayerInfo playerInfo = new PlayerInfo { currentHP = 0, currentMana = 0, currentPos = Vector3.zero, initializedHP = false, maxHP = 0, maxMana = 0, expToNextLvl =0, exp = 0, lvl = 0 }; 

    public GameObject playerInCombat;
    public Transform playerInOverworld;
    public List<GameObject> enemies;
    public string actualScene;
    public string checkpointScene = "Safezone";
    public string sceneBeforeMenu;

    public SpawnSide actualSide;

    public UnitStats playerStats;

    public UnitStats gainValues;

    public delegate void NextLvl();
    public event NextLvl lvlUP;
    
    public struct PlayerInfo
        {
        public float currentHP;
        public float currentMana;
        public Vector3 currentPos;
        public bool initializedHP;
        public float maxHP;
        public float maxMana;
        public float expToNextLvl;
        public float exp;
        public int lvl;
        }


    void Start()
    {
        DontDestroyOnLoad(this);

        Application.targetFrameRate = 60;
        //playerInfo = new PlayerInfo { currentHP = 0, currentMana = 0, currentPos = Vector3.zero, initializedHP = false };

        actualSide = SpawnSide.left;

        playerInfo.currentHP = playerStats.health;
        playerInfo.currentMana = playerStats.mana;
        playerInfo.maxHP = playerStats.health;
        playerInfo.maxMana = playerStats.mana;
        playerInfo.expToNextLvl = playerStats.exp;
        playerInfo.lvl = 1;
        }
    public void LoadScene(string sceneName)
        {
        LoadScene(sceneName, false);
        }
    public void LoadScene(string sceneName, bool repositionPlayer, bool storeScene = false)
        {
        
        if(storeScene)
            {
            actualScene = SceneManager.GetActiveScene().name;
            }
        
        

        IEnumerator LoadSceneAsync()
            {
            var loading = SceneManager.LoadSceneAsync(sceneName);

            yield return new WaitUntil(() => loading.isDone);

            Time.timeScale = 1;

            yield return new WaitUntil(() => playerInOverworld != null);

            if (repositionPlayer)
                {
                playerInOverworld.position = playerInfo.currentPos;
                }
            }

        StartCoroutine(LoadSceneAsync());
        }

    public void SetPlayerInfoAfterDeath()
        {
        playerInfo.currentHP = 1;

        if (playerInfo.currentMana == 0)
            {
            playerInfo.currentMana = 1;
            }
        }

    public void UpdateInfo(bool health, float variationValue)
        {
        if (health)
            {
            if (playerInfo.currentHP + variationValue > playerInfo.maxHP)
                {
                playerInfo.currentHP = playerInfo.maxHP;
                }
            else
                {
                playerInfo.currentHP += variationValue;
                }
            }
        else
            {
            if (playerInfo.currentMana + variationValue > playerInfo.maxMana)
                {
                playerInfo.currentMana = playerInfo.maxMana;
                }
            else
                {
                playerInfo.currentMana += variationValue;
                }
            }
        }

    public void GainExp(float exp, Unit enemy)
        {
        playerInfo.exp += exp;
        if (playerInfo.exp >= playerInfo.expToNextLvl)
            {
            playerInfo.exp -= playerInfo.expToNextLvl;
            playerInfo.expToNextLvl *= 2;
            playerInfo.lvl++;
            lvlUP?.Invoke();
            }
        Debug.Log($"new exp = {playerInfo.exp}");
        IEnumerator WaitDeath()
            {
            yield return new WaitUntil(() => enemy.isDead);
            CombatManager.Instance.AddOnText($"You gained {exp} exp");

            }
        StartCoroutine(WaitDeath());
        }


}
