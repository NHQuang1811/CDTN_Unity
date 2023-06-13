using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SKJump : StateMachineBehaviour
{
    public float timer;
    private bool Jump = false;
    private SwampKing sk;
 
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 1f;
        sk = animator.GetComponent<SwampKing>();
        Jump = false;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(!Jump)
        {
            sk.jump();
            Jump = true;
        }
        if (timer <= 0 && sk.isGrounded)
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
