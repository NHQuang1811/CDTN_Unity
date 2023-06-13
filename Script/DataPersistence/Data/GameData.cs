using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int playerBalance;
    public int HealthPotion;
    public int numOfHealth;
    public Vector3 RespawnPoint;
    public string SceneToLoad;
    public bool GolemIsDead;
    public bool SwampKingIsDead;
    public GameData()
    {
        this.playerBalance = 0;
        this.HealthPotion = 0;
        this.numOfHealth = 4;
        this.RespawnPoint = new Vector3(-32.22f, -4.04f, 0);
        this.SceneToLoad = "SampleScene";
        this.GolemIsDead = false;
        this.SwampKingIsDead = false;
    }
}
