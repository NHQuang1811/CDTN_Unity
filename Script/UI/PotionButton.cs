using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PotionButton : MonoBehaviour
{
    public PlayerBalance player;
    public Button potionButton;
    public Health Health;
    private void Start()
    {
        player = FindObjectOfType<PlayerBalance>();
        Health = FindObjectOfType<Health>();
    }
    public void Heal()
    {
        if (Health.health < Health.numOfHealth && player.HealthPotion > 0 && !DialogueManager.GetInstance().dialoguePlaying)
        {
            player.HealthPotion -= 1;
            Health.health += 1;
            DataPersistenceManager.instance.SaveGame();
            AudioManager.Instance.PlaySFX("Potion");
            potionButton.interactable = false;
            StartCoroutine(HideButton());
        }
    }
    IEnumerator HideButton()
    {
        yield return new WaitForSeconds(10f);
        potionButton.interactable = true;
    }
}
