using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLManager : MonoBehaviour
{
    public static DLManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
