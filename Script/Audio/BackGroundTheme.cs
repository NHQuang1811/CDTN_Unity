using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundTheme : MonoBehaviour
{
    [SerializeField] private string Music;
    private void Start()
    {
        AudioManager.Instance.PlayMusic(Music);
    }
}
