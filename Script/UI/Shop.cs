using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shop;
    public void Click()
    {
        if (!DialogueManager.GetInstance().dialoguePlaying)
        {
            shop.SetActive(true);
            AudioManager.Instance.PlaySFX("UIopen");
        }
    }
}
