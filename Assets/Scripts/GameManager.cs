

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
    {
    public PlayerInfo playerInfo = new PlayerInfo { currentHP = 0, currentMana = 0, currentPos = Vector3.zero, initializedHP = false }; 

    public GameObject playerInCombat;
    public Transform playerInOverworld;
    public List<GameObject> enemies;
    public string actualScene;
    public string checkpointScene = "Safezone";
    public string sceneBeforeMenu;
    
    public struct PlayerInfo
        {
        public float currentHP;
        public float currentMana;
        public Vector3 currentPos;
        public bool initializedHP;
        }

    void Start()
    {
        DontDestroyOnLoad(this);

        
        //playerInfo = new PlayerInfo { currentHP = 0, currentMana = 0, currentPos = Vector3.zero, initializedHP = false };
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


}
