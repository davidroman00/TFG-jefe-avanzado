
using UnityEngine;

public class BossSweepState : StateMachineBehaviour
{
    EntityAudioManager _entityAudioManager;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _entityAudioManager = animator.GetComponent<EntityAudioManager>();
        _entityAudioManager.PlaySound(animator.GetComponent<BossReferences>().BossSweepLoopAudio, .5f, .725f, .8f, false);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("sweep");
        _entityAudioManager.StopSound();
    }
}
