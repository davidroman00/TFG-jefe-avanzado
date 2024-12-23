
using UnityEngine;

public class BossDodgeLeftState : StateMachineBehaviour
{
    BossStats _bossStats;
    BossReferences _bossReferences;
    float _dodgeSpeedMultiplier;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossStats = animator.GetComponent<BossStats>();
        _bossReferences = animator.GetComponent<BossReferences>();
        animator.GetComponent<EntityAudioManager>().PlaySound(_bossReferences.BossDodgeAudio, .7f, 1f, .65f, false);
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
            animator.transform.Translate((_bossStats.DodgeMovementSpeed + _dodgeSpeedMultiplier) * Time.deltaTime * Vector3.left);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossReferences.HasReachedMidDodge = false;
        animator.GetComponent<BossCooldownManager>().LastDodge = Time.time;
        animator.ResetTrigger("dodgeLeft");
        animator.ResetTrigger("dodgeRight");
    }
}

