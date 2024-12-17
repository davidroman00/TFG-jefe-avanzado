
using UnityEngine;

public class CharacterHealState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<CharacterCooldownManager>().LastHeal = Time.time;
        animator.GetComponent<CharacterStats>().HealCharges--;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("heal");
    }
}
