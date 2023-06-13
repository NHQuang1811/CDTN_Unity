using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    Animator anmt;
    private CircleCollider2D cc;

    private void Start()
    {
        anmt = GetComponent<Animator>();
        cc = GetComponent<CircleCollider2D>();
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
        cc.enabled = false;
        anmt.SetTrigger("explode");
        if (collision.gameObject.CompareTag("Player"))
        {
        }
    }
    private void Deactivate()
    {
        Destroy(gameObject);
    }
}
