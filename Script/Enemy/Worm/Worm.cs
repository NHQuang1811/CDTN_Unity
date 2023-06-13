using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Worm : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lineOfSite;
    private bool Engage = false;
    private bool isHit = false;
    Transform player;
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject SpitBall;
    public Transform attackPoint;
    public float timer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        if (distance < lineOfSite)
        {
            Engage = true;
        }
        if (Engage || isHit)
        {
            if (Vector2.Distance(player.position, rb.position) < 7f)
            {
                if (timer > 4)
                {
                    Spit();
                    timer = 0;
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
            else if(Vector2.Distance(player.position, rb.position) >= 5f)
            {
                GoToward();
                animator.SetTrigger("walk");
            }
        }
        Rotate();
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
    private void GoToward()
    {
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }
    private void Rotate()
    {
        if (player.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void Spit()
    {
        Instantiate(SpitBall, attackPoint.position,transform.rotation);
        AudioManager.Instance.PlaySFX("Spit");
    }
}
