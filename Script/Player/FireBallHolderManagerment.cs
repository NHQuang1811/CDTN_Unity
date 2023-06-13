using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallHolderManagerment : MonoBehaviour
{
    public static FireBallHolderManagerment instance;
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
}
