using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Golem : MonoBehaviour
{
    public float speed = 2f;
    private Transform Player;
    public bool isAttacking = false;
    private bool isFacingRight = true;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (!isAttacking)
        {
            Move();
        }
    }

    private void Move()
    {
        if (Player.position.x < transform.position.x && isFacingRight)
        {
            Flip();
        }

        else if (Player.position.x > transform.position.x && !isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
