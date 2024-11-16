using UnityEngine;

public class BossMeleeStateManager : StateMachineBehaviour
{
    BossCooldownManager _bossCooldownManager;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossCooldownManager = animator.GetComponent<BossCooldownManager>();
        _bossCooldownManager.LastMelee = Time.time;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // animator.ResetTrigger("meleeSimple");
        // if (_bossCooldownManager.IsPatternMeleeOnCooldown() && _bossCooldownManager.IsSimpleMeleeOnCooldown())
        // {
        //     animator.SetBool("anyMeleeReady", false);
        // }
    }
}
