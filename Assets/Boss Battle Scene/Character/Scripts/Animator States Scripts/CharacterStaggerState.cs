
using UnityEngine;

public class CharacterStaggerState : StateMachineBehaviour
{
    CharacterReferences _characterReferences;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _characterReferences = animator.GetComponent<CharacterReferences>();
        _characterReferences.IsStaggered = true;
        animator.GetComponent<CharacterCooldownManager>().LastStagger = Time.time;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("stagger");
        _characterReferences.IsStaggered = false;
    }
}
