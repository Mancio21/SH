using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneOnEnd : StateMachineBehaviour
{

    public string sceneName;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        GameManager.Instance.LoadScene(sceneName);
        }
    }
