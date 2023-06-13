using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCCShop : MonoBehaviour
{
    [SerializeField] private int price;
    public PlayerBalance player;
    public GameObject Shop;
    public GameObject warning;
    public void Price()
    {
        if (player.playerBalance >= price)
        {
            if(player.HealthPotion < 10)
            {
                player.playerBalance = player.playerBalance - price;
                player.HealthPotion += 1;
                AudioManager.Instance.PlaySFX("Coin");
                DataPersistenceManager.instance.SaveGame();
            }
            warning.SetActive(false);
        }
        else
        {
            warning.SetActive(true);
        }
    }
    public void Exit()
    {
        warning.SetActive(false);
        Shop.SetActive(false);
    }
}
