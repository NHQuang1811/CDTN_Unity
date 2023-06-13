using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public GameObject PauseMenu;

    public void ShowMenu()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
