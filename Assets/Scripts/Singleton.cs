﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    //Classe generica per i singleton
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance != null)
            {
                return instance;
            }
            else
            {
                return null;
            }
        }
    }

    public void Awake()
    {
        instance = this as T;
    }
}
