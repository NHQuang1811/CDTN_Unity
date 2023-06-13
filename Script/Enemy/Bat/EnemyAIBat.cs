using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAIBat : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lineOfSite;
    private Transform Player;
    private bool Engage = false;
    private bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(Player.position, transform.position);
        if (distance < lineOfSite)
        {
            Engage = true;
        }
        if (Engage || isHit)
        {
            FlyToward();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            isHit = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }

    private void FlyToward()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, Player.position, speed * Time.deltaTime);
        if (Player.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
