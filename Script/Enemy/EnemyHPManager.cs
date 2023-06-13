using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPManager : MonoBehaviour
{
    public int HitPoint;
    public DropManager[] dropItems;
    public void TakeDamage(int damage)
    {
        HitPoint -= damage;
        if (HitPoint <= 0)
        {
            DropItem();
            AudioManager.Instance.PlaySFX("EnemyDeath");
            Destroy(gameObject);
        }
    }
    private void DropItem()
    {
        foreach (DropManager dropManager in dropItems)
        {
            for (int i = 0; i < dropManager.quantity; i++)
            {
                Instantiate(dropManager.itemToDrop, transform.position, Quaternion.identity);
            }
        }
    }
}
