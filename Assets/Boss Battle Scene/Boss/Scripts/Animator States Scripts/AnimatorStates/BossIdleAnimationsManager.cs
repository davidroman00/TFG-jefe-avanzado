using UnityEngine;

public class BossIdleAnimationsManager : StateMachineBehaviour
{
    //This is the core logic of the animator.
    BossStats _bossStats;
    BossReferences _bossReferences;
    BossCooldownManager _bossCooldownManager;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossStats = animator.GetComponent<BossStats>();
        _bossReferences = animator.GetComponent<BossReferences>();
        _bossCooldownManager = animator.GetComponent<BossCooldownManager>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MeleeChecker(animator);
        FanChecker(animator);
        SweepChecker(animator);
        CrossChecker(animator);
        BuffChecker(animator);
        DebuffChecker(animator);
        DodgeChecker(animator);
        UltimateChecker(animator);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("melee");
        animator.ResetTrigger("fan");
        animator.ResetTrigger("sweep");
        animator.ResetTrigger("sweepBreak");
        animator.ResetTrigger("notSweepBreak");
        animator.ResetTrigger("sweepBreakEnd");
        animator.ResetTrigger("cross");
        animator.ResetTrigger("buff");
        animator.ResetTrigger("debuff");
        animator.ResetTrigger("dodgeLeft");
        animator.ResetTrigger("dodgeRight");
        animator.ResetTrigger("ultimate");
        animator.ResetTrigger("ultimateBreak");
        animator.ResetTrigger("ultimateBreakEnd");
        //Resetting triggers at the exit of this state is important, so triggers don't stack in the animator while waiting for the current animation to end.
        //It only happens if two, or more, of them are set at the same time.
    }
    //The conditions behind every movement to trigger.
    void MeleeChecker(Animator animator)
    {
        if (!_bossCooldownManager.IsMeleeOnCooldown())
        {
            animator.SetTrigger("melee");
        }
    }
    void FanChecker(Animator animator)
    {
        if (!_bossCooldownManager.IsFanOnCooldown())
        {
            animator.SetTrigger("fan");
        }
    }
    void SweepChecker(Animator animator)
    {
        if (!_bossCooldownManager.IsSweepOnCooldown() && !_bossReferences.IsBuffActive)
        {
            animator.SetTrigger("sweep");
        }
    }
    void CrossChecker(Animator animator)
    {
        if (!_bossCooldownManager.IsCrossOnCooldown())
        {
            animator.SetTrigger("cross");
        }
    }
    void BuffChecker(Animator animator)
    {
        if (!_bossCooldownManager.IsBuffOnCooldown())
        {
            animator.SetTrigger("buff");
        }
    }
    void DebuffChecker(Animator animator)
    {
        if (!_bossCooldownManager.IsDebuffOnCooldown())
        {
            animator.SetTrigger("debuff");
        }
    }
    void DodgeChecker(Animator animator)
    {
        if (!_bossCooldownManager.IsDodgeOnCooldown() /*&& la confirmacion de si una flecha esta cerca suyo*/)
        {
            float randomDodgeDirection = Random.value;
            if (randomDodgeDirection > .49f){
                animator.SetTrigger("dodgeLeft");
            }
            else
            {
                animator.SetTrigger("dodgeRight");
            }
        }
    }
    void UltimateChecker(Animator animator)
    {
        if (_bossReferences.ActualUltimateUses < _bossStats.BossMaxUltimateUses && _bossStats.CurrentHP <= _bossStats.BossUltimateHPThreshold && !_bossCooldownManager.IsUltimateOnCooldown() && !_bossReferences.IsBuffActive)
        {
            animator.SetTrigger("ultimate");
            _bossReferences.ActualUltimateUses++;
        }
    }
}