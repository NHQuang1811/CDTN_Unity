using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    public int ProjectileDamage;
    Animator anmt;
    private BoxCollider2D bc;

    private void Start()
    {
        anmt = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
        Collider2D[] colliders = FindObjectsOfType<Collider2D>();
        Collider2D projectileCollider = GetComponent<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.layer == LayerMask.NameToLayer("CamZone"))
            {
                Physics2D.IgnoreCollision(collider, projectileCollider);
            }
        }
    }
    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
        Object.Destroy(gameObject, 1.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bc.enabled = false;
        anmt.SetTrigger("explode");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHPManager enemyHP = collision.gameObject.GetComponent<EnemyHPManager>();
            if (enemyHP != null)
            {
                enemyHP.TakeDamage(ProjectileDamage);
                AudioManager.Instance.PlaySFX("EnemyHit");
            }
        }
    }
    private void Deactivate()
    {
        Destroy(gameObject);
    }
}
