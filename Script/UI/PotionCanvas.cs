using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PotionCanvas : MonoBehaviour
{
    public TextMeshProUGUI potionNumber;
    public PlayerBalance player;
    private void Start()
    {
        potionNumber = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<PlayerBalance>();
    }
    private void Update()
    {
        potionNumber.text = player.HealthPotion.ToString();
    }
}
