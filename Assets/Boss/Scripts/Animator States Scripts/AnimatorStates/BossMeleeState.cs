
using UnityEngine;

public class BossMeleeState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<BossAudioManager>().PlayBossSound(animator.GetComponent<BossReferences>().BossMeleeRoarAudio, 1, 1f, .5f, !true);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("melee");
    }
}
