using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBalance : MonoBehaviour, IDataPersistence
{
    public int playerBalance;
    public int HealthPotion;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "currency")
        {
            playerBalance += 1;
            AudioManager.Instance.PlaySFX("Coin");
            DataPersistenceManager.instance.SaveGame();
        }
    }
    public void LoadData(GameData data)
    {
        this.playerBalance = data.playerBalance;
        this.HealthPotion = data.HealthPotion;
    }
    public void SaveData(GameData data)
    {
        data.playerBalance = this.playerBalance;
        data.HealthPotion = this.HealthPotion;
    }
}
