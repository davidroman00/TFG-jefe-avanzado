using UnityEngine;

public class BossUltimateState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<BossAudioManager>().PlayBossSound(animator.GetComponent<BossReferences>().BossUltimateChargeAudio, 1, 1f, .5f, false);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (FindAnyObjectByType<BossUltimateDevice>() && FindAnyObjectByType<BossUltimateDevice>().IsDeviceDestroyed)
        //This double-checking is necessary so, during the first frames, you don't get a NullReferenceException; since Unity needs some time to locate the object.
        {
            animator.SetTrigger("ultimateBreak");
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<BossCooldownManager>().LastUltimate = Time.time;
        animator.ResetTrigger("ultimate");
        animator.GetComponent<BossAudioManager>().StopBossSound();
    }
}
