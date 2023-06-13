using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAttack : StateMachineBehaviour
{
    public float timer;
    public float minTime;
    public float maxTime;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        AudioManager.Instance.PlaySFX("GolemAttackBeam");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            animator.SetTrigger("LazeTrap");
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
