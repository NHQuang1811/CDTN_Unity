using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public DropManager[] dropItems;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            DropItem();
            Destroy(this.gameObject);
            AudioManager.Instance.PlaySFX("Barrel");
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
