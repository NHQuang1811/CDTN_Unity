using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SKMove : StateMachineBehaviour
{
    public float timer;
    public float rand;
    public float speed = 2.5f;
    Transform player;
    Rigidbody2D rb;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        timer = 1f;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        if (timer <= 0)
        {
            if (Vector2.Distance(player.position, rb.position) < 3.8f)
            {
                animator.SetTrigger("Spike");
            }
            else
            {
                if(rand == 0)
                {
                    AudioManager.Instance.PlaySFX("SKprep");
                    animator.SetTrigger("Jump");
                    rand = 1;
                }
                else if(rand == 1)
                {
                    animator.SetTrigger("Shoot");
                    rand = 0;
                }
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }

    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
