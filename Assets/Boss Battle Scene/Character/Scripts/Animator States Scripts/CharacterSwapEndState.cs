
using UnityEngine;

public class CharacterSwapEndState : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<CharacterReferences>().IsSwapping = false;
        animator.ResetTrigger("swap");
    }
}
