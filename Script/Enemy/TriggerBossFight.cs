using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBossFight : MonoBehaviour, IDataPersistence
{
    public GameObject bossPrefab;
    public Transform spawnPoint;
    public bool GolemIsDead = false;
    public GameObject door;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GolemIsDead == false)
        {
            if (collision.gameObject.tag == "Player")
            {
                Instantiate(bossPrefab, spawnPoint.position, transform.rotation);
                Destroy(gameObject);
                AudioManager.Instance.PlaySFX("DoorOpen");
                door.SetActive(true);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void LoadData(GameData data)
    {
        this.GolemIsDead = data.GolemIsDead;
    }
    public void SaveData(GameData data)
    {
    }
}
