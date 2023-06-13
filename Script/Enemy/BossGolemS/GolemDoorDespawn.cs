using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GolemDoorDespawn : MonoBehaviour, IDataPersistence
{
    public bool despawn;
    private void Update()
    {
        if(despawn)
        {
            gameObject.SetActive(false);
            AudioManager.Instance.PlaySFX("DoorClose");
        }
    }
    public void LoadData(GameData data)
    {
        this.despawn = data.GolemIsDead;
    }
    public void SaveData(GameData data)
    {
    }
}
