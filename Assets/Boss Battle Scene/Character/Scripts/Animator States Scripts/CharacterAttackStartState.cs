
using UnityEngine;

public class CharacterAttackStartState : StateMachineBehaviour
{
    CharacterReferences _characterReferences;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _characterReferences = animator.GetComponent<CharacterReferences>();
        _characterReferences.IsAttacking = true;
        _characterReferences.IsAttackStoredAndNotPerformed = false;
    }
}
