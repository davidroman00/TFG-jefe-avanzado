
using UnityEngine;

public class BossSweepState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<BossAudioManager>().PlayBossSound(animator.GetComponent<BossReferences>().BossSweepLoopAudio, .5f, .725f, .8f, false);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("sweep");
        animator.GetComponent<BossAudioManager>().StopBossSound();
    }
}
