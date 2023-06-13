using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIFrog : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] float moveSpeed;
    private bool facingRight = true;
    [SerializeField] LayerMask groundLayer;
    private Rigidbody2D rb;
    private Animator animator;

    [Header("Jump")]
    [SerializeField] float jumpHeight;
    private Transform player;
    [SerializeField] Transform groundJump;
    [SerializeField] Vector2 boxSize;
    private bool isGrounded;

    [Header("Engage")]
    [SerializeField] private float lineOfSite;
    private bool Engage = false;
    private bool isHit = false;
    public float timer;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox(groundJump.position, boxSize, 0,groundLayer);
        float distance = Vector2.Distance(player.position, transform.position);
        if (distance < lineOfSite)
        {
            Engage = true;
        }
        if (Engage || isHit)
        {
            if (isGrounded)
            {
                if (timer > 2)
                {
                    jump();
                    timer = 0;
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
        }
        FlipTowardPlayer();
        AnimationState();
    }
    private void jump()
    {
        float distanceFromPlayer = player.position.x - transform.position.x;
        AudioManager.Instance.PlaySFX("Frog");
        if (distanceFromPlayer > 10f)
        {
            distanceFromPlayer = 10f;
        }
        else if (distanceFromPlayer < -10f)
        {
            distanceFromPlayer = -10f;
        }
        rb.AddForce(new Vector2(distanceFromPlayer, jumpHeight), ForceMode2D.Impulse);
    }
    private void AnimationState() 
    {
        if (rb.velocity.y > .1f)
        {
            animator.SetTrigger("jump");
        }
        else if (rb.velocity.y < -.1f)
        {
            animator.SetTrigger("fall");
        }
        else if (rb.velocity.y == 0f)
        {
            animator.SetTrigger("Idle");
        }
    }
    private void FlipTowardPlayer()
    {
        float playerPossition = player.position.x - transform.position.x;
        if(playerPossition < 0 && facingRight)
        {
            Flip();
        }
        else if(playerPossition > 0 && !facingRight)
        {
            Flip();
        }
    }
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(groundJump.position, boxSize);
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            isHit = true;
        }
    }
}
