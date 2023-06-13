using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemGoToSpawn : StateMachineBehaviour
{
    public float timer;
    public float minTime;
    public float maxTime;
    public float speed = 2.5f;
    public GameObject laze;
    Transform LazePoint;
    Transform Spawn;
    Rigidbody2D rb;
    bool hasInstantiated = false;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        Spawn = GameObject.FindGameObjectWithTag("Spawn").transform;
        LazePoint = GameObject.FindGameObjectWithTag("LazePoint").transform;
        hasInstantiated = false;
        rb = animator.GetComponent<Rigidbody2D>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new Vector2(Spawn.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        if (!hasInstantiated)
        {
            Instantiate(laze, LazePoint.position, Quaternion.identity);
            AudioManager.Instance.PlaySFX("GolemAttackBeam");
            hasInstantiated = true;
        }
        rb.MovePosition(newPos);
        if (timer <= 0)
        {
            animator.SetTrigger("Idle");
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
