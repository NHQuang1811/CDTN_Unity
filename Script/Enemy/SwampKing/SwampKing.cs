using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwampKing : MonoBehaviour
{
    private Transform Player;
    private bool isFacingRight = false;
    [SerializeField] Transform groundJump;
    [SerializeField] Vector2 boxSize;
    public bool isGrounded;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float jumpHeight;
    private Rigidbody2D rb;
    public Transform SKShootPoint;
    public GameObject SKbullet;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        AudioManager.Instance.PlayMusic("BossSwampKing");
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox(groundJump.position, boxSize, 0, groundLayer);
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if (Player.position.x > transform.position.x && !isFacingRight)
        {
            Flip();
        }

        else if (Player.position.x <= transform.position.x && isFacingRight)
        {
            Flip();
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    public void jump()
    {
        float distanceFromPlayer = Player.position.x - transform.position.x;
        AudioManager.Instance.PlaySFX("SKJump");
        if (isGrounded)
        {
            rb.AddForce(new Vector2(distanceFromPlayer, jumpHeight), ForceMode2D.Impulse);
        }
    }
    public void SKShoot()
    {
        StartCoroutine(shoot());
    }
    IEnumerator shoot()
    {
        yield return new WaitForSeconds(0.5f);
        AudioManager.Instance.PlaySFX("Spit");
        Instantiate(SKbullet, SKShootPoint.position, transform.rotation);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(groundJump.position, boxSize);
    }
}
