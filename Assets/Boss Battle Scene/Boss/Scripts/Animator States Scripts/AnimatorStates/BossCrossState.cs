using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCrossState : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("cross");
    }
}
