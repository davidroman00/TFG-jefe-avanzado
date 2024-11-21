using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDebuffState : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<BossCooldownManager>().LastDebuff = Time.time;
        animator.ResetTrigger("debuff");
    }
}
