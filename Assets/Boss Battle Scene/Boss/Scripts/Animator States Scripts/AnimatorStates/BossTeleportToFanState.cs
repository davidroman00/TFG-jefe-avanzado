using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTeleportToFanState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int randomFanPosition = Random.Range(0, animator.GetComponent<BossReferences>().FanBossPositions.Length);
        animator.GetComponent<BossReferences>().ActualTeleportPosition = animator.GetComponent<BossReferences>().FanBossPositions[randomFanPosition];
    }
}
