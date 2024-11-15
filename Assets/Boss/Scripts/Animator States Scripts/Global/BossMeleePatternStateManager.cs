using UnityEngine;

public class BossMeleePatternStateManager : StateMachineBehaviour
{
    BossCooldownManager _bossCooldownManager;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossCooldownManager = animator.GetComponent<BossCooldownManager>();
        _bossCooldownManager.LastPatternMelee = Time.time;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // animator.ResetTrigger("meleePattern");
        // if (_bossCooldownManager.IsPatternMeleeOnCooldown() && _bossCooldownManager.IsSimpleMeleeOnCooldown())
        // {
        //     animator.SetBool("anyMeleeReady", false);
        // }
    }
}
