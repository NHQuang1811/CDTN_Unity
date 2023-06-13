using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGolemHPManager : MonoBehaviour
{
    public int HitPoint;
    public DropManager[] dropItems;
    private Animator animator;
    private bool isDropped = false;
    private GameObject bossDoor;

    private void Start()
    {
        animator = GetComponent<Animator>();
        bossDoor = GameObject.FindGameObjectWithTag("bossDoor");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            TakeDamages();
        }
    }
    public void TakeDamages()
    {
        HitPoint -= 1;
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
    private void Update()
    {
        if (HitPoint <= 0)
        {
            Dead();
        }
    }
    public void Dead()
    {
        if (!isDropped)
        {
            AudioManager.Instance.PlaySFX("GolemDeath");
            animator.SetTrigger("Defeat");
            DropItem();
            isDropped = true;
            if (bossDoor != null)
            {
                bossDoor.SetActive(false);
            }
        }
        Destroy(gameObject, 1.11f);
    }
}
