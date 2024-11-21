using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeState : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<BossCooldownManager>().LastMelee = Time.time;
        animator.ResetTrigger("melee");
    }
}
