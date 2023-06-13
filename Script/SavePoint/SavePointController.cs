using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;

public class SavePointController : MonoBehaviour, IDataPersistence
{
    public string SceneToLoad;
    public void LoadData(GameData data)
    {
    }
    public void SaveData(GameData data)
    {
        data.SceneToLoad = this.SceneToLoad;
        data.RespawnPoint = this.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DataPersistenceManager.instance.SaveGame();
        }
    }
}
