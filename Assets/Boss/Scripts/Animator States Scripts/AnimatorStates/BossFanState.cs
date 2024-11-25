using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFanState : StateMachineBehaviour
{
    BossReferences _bossReferences;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossReferences = animator.GetComponent<BossReferences>();
        int randomFanPosition = Random.Range(0, _bossReferences.FanBossPositions.Length);
        _bossReferences.ActualTeleportPosition = _bossReferences.FanBossPositions[randomFanPosition];
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("fan");
    }
}
