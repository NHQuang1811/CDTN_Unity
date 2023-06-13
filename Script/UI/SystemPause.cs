using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemPause : MonoBehaviour
{
    public GameObject PauseMenu;
    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
