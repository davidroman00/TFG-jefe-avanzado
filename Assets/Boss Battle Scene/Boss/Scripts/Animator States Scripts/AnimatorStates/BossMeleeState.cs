
using UnityEngine;

public class BossMeleeState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EntityAudioManager>().PlaySound(animator.GetComponent<BossReferences>().BossMeleeRoarAudio, .75f, .85f, .65f, false);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("melee");
    }
}
