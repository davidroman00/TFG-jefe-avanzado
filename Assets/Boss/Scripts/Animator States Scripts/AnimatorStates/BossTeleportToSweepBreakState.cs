
using UnityEngine;

public class BossTeleportToSweepBreakState : StateMachineBehaviour
{
override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<BossReferences>().ActualTeleportPosition = animator.GetComponent<BossReferences>().CrossBossPosition;
    }
}
