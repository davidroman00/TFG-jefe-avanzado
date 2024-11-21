using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDodgeRightState : StateMachineBehaviour
{
    BossStats _bossStats;
    BossReferences _bossReferences;
    float _dodgeSpeedMultiplier;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossStats = animator.GetComponent<BossStats>();
        _bossReferences = animator.GetComponent<BossReferences>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_bossReferences.HasReachedMidDodge)
        {
            _dodgeSpeedMultiplier += _bossStats.DodgeAccelerationSpeed * Time.deltaTime;
        }
        else if (_bossReferences.HasReachedMidDodge)
        {
            _dodgeSpeedMultiplier -= _bossStats.DodgeAccelerationSpeed * Time.deltaTime;
        }
        
        if (_bossReferences.IsActualDodgeActive && !_bossReferences.IsOutsideArena)
        {
            animator.transform.Translate((_bossStats.DodgeMovementSpeed * 1 + _dodgeSpeedMultiplier / 100) * Time.deltaTime * Vector3.right);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossReferences.HasReachedMidDodge = false;
        animator.GetComponent<BossCooldownManager>().LastDodge = Time.time;
        animator.ResetTrigger("dodgeRight");
    }
}
