
using UnityEngine;

public class CharacterHealState : StateMachineBehaviour
{
    CharacterReferences _characterReferences;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _characterReferences = animator.GetComponent<CharacterReferences>();
        _characterReferences.IsHealing = true;
        animator.GetComponent<CharacterCooldownManager>().LastHeal = Time.time;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("heal");
        _characterReferences.IsHealing = false;
    }
}
