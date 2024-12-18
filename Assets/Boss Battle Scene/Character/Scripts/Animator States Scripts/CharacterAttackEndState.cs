
using UnityEngine;

public class CharacterAttackEndState : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("fire1");
        animator.GetComponent<CharacterReferences>().IsAttacking = false;
        animator.GetComponentInChildren<CharacterMeleeWeapon>().enabled = false;
    }
}
