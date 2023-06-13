using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntranceScene : MonoBehaviour
{
    public string lastExitName;
    void Start()
    {
        if (PlayerPrefs.GetString("lastExitName") == lastExitName)
        {
            PlayerManager.Instance.transform.position = transform.position;
        }
    }
}
