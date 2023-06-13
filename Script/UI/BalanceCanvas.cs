using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalanceCanvas : MonoBehaviour
{
    public TextMeshProUGUI balanceText;
    public PlayerBalance player;
   
    private void Start()
    {
        balanceText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<PlayerBalance>();
    }
    private void Update()
    {
        balanceText.text = player.playerBalance.ToString();
    }
}
