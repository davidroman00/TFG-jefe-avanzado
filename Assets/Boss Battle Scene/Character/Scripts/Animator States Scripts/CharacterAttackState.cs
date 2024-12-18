using UnityEngine;

public class CharacterAttackState : StateMachineBehaviour
{   
    CharacterReferences _characterReferences;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _characterReferences = animator.GetComponent<CharacterReferences>(); 
        _characterReferences.IsAttacking = true;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("attack");
        _characterReferences.IsAttacking = false;
        animator.GetComponentInChildren<CharacterMeleeWeapon>().enabled = false;
    }
}