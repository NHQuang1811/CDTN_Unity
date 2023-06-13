using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKShoot : StateMachineBehaviour
{
    public float timer;
    bool hasInstantiated = false;
    private SwampKing sk;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 1f;
        hasInstantiated = false;
        sk = animator.GetComponent<SwampKing>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!hasInstantiated)
        {
            sk.SKShoot();
            hasInstantiated = true;
        }
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
