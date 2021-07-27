using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : Singleton<LoadScene>
{
    public void NextScene(string name)
        {
        SceneManager.LoadScene(name);
        }
}
