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
        _characterReferences.IsDodging = true; //This line here is necessary to avoid the character moving while the animation lasts.
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_characterReferences.IsActualDodgeActive)
        {
            _characterController.Move(_characterStats.DodgeMovementSpeed * Time.deltaTime * _characterReferences.DodgeMoveDirection.normalized);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("backdash");
        _characterReferences.IsDodging = false;
    }
}