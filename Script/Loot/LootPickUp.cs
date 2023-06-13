using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LootPickUp : MonoBehaviour
{
    private Rigidbody2D _rigi;
    private void Start()
    {
        _rigi = GetComponent<Rigidbody2D>();
        _rigi.AddForce(new Vector2(Random.Range(-3f, 3f), 2f), ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
