using UnityEngine;

public class CharacterBackdashStateManager : StateMachineBehaviour
{
    CharacterStats _characterStats;
    CharacterReferences _characterReferences;
    CharacterController _characterController;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _characterReferences = animator.GetComponent<CharacterReferences>();
        _characterController = animator.GetComponent<CharacterController>();
        _characterStats = animator.GetComponent<CharacterStats>();
        _characterReferences.IsDashing = true; //This line here is necessary to avoid the character moving while the animation lasts.
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_characterReferences.IsActualDashActive)
        {
            _characterController.Move(_characterStats.DashMovementSpeed * Time.deltaTime * _characterReferences.DashMoveDirection.normalized);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("backdash");
        _characterReferences.IsDashing = false;
    }
}