using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSweepState : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<BossCooldownManager>().LastSweep = Time.time;
        animator.ResetTrigger("sweep");
    }
}
