using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTeleportToUltimateState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<BossReferences>().ActualTeleportPosition = animator.GetComponent<BossReferences>().UltimateBossPosition;
    }
}
