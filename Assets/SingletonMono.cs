using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMono : MonoBehaviour
{
    public static SingletonMono instance;
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }
}
