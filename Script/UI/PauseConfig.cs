using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseConfig : MonoBehaviour
{
    public GameObject PauseMenu;
    public void Continue()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Exit()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
        Destroy(GameObject.Find("Player"));
        Destroy(GameObject.Find("Canvas"));
        Destroy(GameObject.Find("DialogCanvas"));
        Destroy(GameObject.Find("Manager"));
        Destroy(GameObject.Find("Audio Manager"));
    }
}
