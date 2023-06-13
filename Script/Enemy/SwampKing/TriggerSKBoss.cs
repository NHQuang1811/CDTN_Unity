using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSKBoss : MonoBehaviour, IDataPersistence
{
    public GameObject bossPrefab;
    public Transform spawnPoint;
    public bool SwampKingIsDead = false;
    public GameObject door;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SwampKingIsDead == false)
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
        this.SwampKingIsDead = data.SwampKingIsDead;
    }
    public void SaveData(GameData data)
    {
    }
}
