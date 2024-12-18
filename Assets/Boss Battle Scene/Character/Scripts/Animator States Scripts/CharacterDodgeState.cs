
using UnityEngine;

public class CharacterDodgeState : StateMachineBehaviour
{
    CharacterStats _characterStats;
    CharacterReferences _characterReferences;
    CharacterController _characterController;
    float _dodgeSpeedMultiplier;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _characterReferences = animator.GetComponent<CharacterReferences>();
        _characterStats = animator.GetComponent<CharacterStats>();
        _characterController = animator.GetComponent<CharacterController>();
        animator.GetComponent<CharacterStaminaManager>().ReduceStamina(_characterStats.DodgeStaminaConsumption);
        _characterReferences.IsDodging = true; //This line here is necessary to avoid the character moving while the animation lasts.
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_characterReferences.IsActualDodgeActive)
        {
            if (!_characterReferences.HasReachedMidDodge)
            {
                _dodgeSpeedMultiplier += _characterStats.DodgeAccelerationSpeed * Time.deltaTime;
            }
            else
            {
                _dodgeSpeedMultiplier -= _characterStats.DodgeAccelerationSpeed * Time.deltaTime;
            }
            _characterController.Move((_characterStats.DodgeMovementSpeed + _dodgeSpeedMultiplier) * Time.deltaTime * _characterReferences.DodgeMoveDirection.normalized);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("dodge");
        _characterReferences.IsDodging = false;
        _characterReferences.HasReachedMidDodge = false;
    }
}
