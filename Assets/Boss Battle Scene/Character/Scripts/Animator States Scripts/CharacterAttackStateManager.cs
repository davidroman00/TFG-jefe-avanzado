using UnityEngine;

public class CharacterAttackStateManager : StateMachineBehaviour
{   
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<CharacterReferences>().IsAttacking = true; //This line here is necessary to avoid the character moving while the animation lasts.
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("attack");
        animator.GetComponent<CharacterReferences>().IsAttacking = false;
        animator.GetComponentInChildren<CharacterMeleeWeapon>().enabled = false;
    }
}