using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBossHolder : MonoBehaviour, IDataPersistence
{
    public bool GolemIsDead;
    public bool SwampKingIsDead;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GolemMedal")
        {
            GolemIsDead = true;
            DataPersistenceManager.instance.SaveGame();
        }
        if (collision.gameObject.tag == "SKMedal")
        {
            SwampKingIsDead = true;
            DataPersistenceManager.instance.SaveGame();
        }
    }
    public void LoadData(GameData data)
    {
        this.GolemIsDead = data.GolemIsDead;
        this.SwampKingIsDead = data.SwampKingIsDead;
    }
    public void SaveData(GameData data)
    {
        data.GolemIsDead = this.GolemIsDead;
        data.SwampKingIsDead = this.SwampKingIsDead;
    }
}
