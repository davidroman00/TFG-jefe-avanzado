using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBuffState : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("buff");
    }
}
