using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour, IDataPersistence
{
    [Header("Menu Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;
    private string Scene;
    private void Start()
    {
        if(!DataPersistenceManager.instance.HasGameData())
        {
            continueGameButton.interactable = false;
        }
    }
    public void NewGame()
    {
        DisableMenuButton();
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void LoadGame()
    {
        DisableMenuButton();
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadSceneAsync("SampleScene");
        if(Scene != "SampleScene")
        {
            SceneManager.LoadSceneAsync(Scene);
        }
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has quit");
    }
    private void DisableMenuButton()
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }
    public void LoadData(GameData data)
    {
        this.Scene = data.SceneToLoad;
    }
    public void SaveData(GameData data)
    {
    }
}
