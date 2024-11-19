using UnityEngine;

public class BossIdleAnimationsManager : StateMachineBehaviour
{
    //This is the core logic of the animator.
    BossHealthManager _bossHealthManager;
    BossStats _bossStats;
    BossReferences _bossReferences;
    BossCooldownManager _bossCooldownManager;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossHealthManager = animator.GetComponentInChildren<BossHealthManager>();
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
        UltimateChecker(animator);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("melee");
        animator.ResetTrigger("fan");
        animator.ResetTrigger("sweep");
        animator.ResetTrigger("cross");
        animator.ResetTrigger("buff");
        animator.ResetTrigger("debuff");
        animator.ResetTrigger("ultimate");
        //Resetting triggers at the exit of this state is important, so triggers don't stack in the animator while waiting for the current animation to end.
        //It only happens if two, or more, of them are set at the same time.
    }
    //The conditions behind every movement to trigger.
    void MeleeChecker(Animator animator)
    {
        if (!_bossCooldownManager.IsMeleeOnCooldown())
        {
            _bossReferences.ActualTeleportPosition = _bossReferences.MeleeAttackPosition;
            animator.SetTrigger("melee");
        }
    }
    void FanChecker(Animator animator)
    {
        if (!_bossCooldownManager.IsFanOnCooldown())
        {
            int randomFanPosition = Random.Range(0, _bossReferences.FanBossPositions.Length);
            _bossReferences.ActualTeleportPosition = _bossReferences.FanBossPositions[randomFanPosition];
            animator.SetTrigger("fan");
        }
    }
    void SweepChecker(Animator animator)
    {
        if (!_bossCooldownManager.IsSweepOnCooldown())
        {
            _bossReferences.ActualTeleportPosition = _bossReferences.SweepBossPosition;
            animator.SetTrigger("sweep");
        }
    }
    void CrossChecker(Animator animator)
    {
        if (!_bossCooldownManager.IsCrossOnCooldown())
        {
            _bossReferences.ActualTeleportPosition = _bossReferences.CrossBossPosition;
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
            int randomDodgeDirection = Random.Range(1, 2);
            if (randomDodgeDirection == 1)
                animator.SetTrigger("dodgeLeft");
            else
                animator.SetTrigger("dodgeRight");
        }
    }
    void UltimateChecker(Animator animator)
    {
        if (_bossReferences.ActualUltimateUses < _bossStats.BossMaxUltimateUses && _bossHealthManager.CurrentHealth <= _bossStats.BossUltimateHPThreshold && !_bossCooldownManager.IsUltimateOnCooldown())
        {
            _bossReferences.ActualTeleportPosition = _bossReferences.UltimateBossPosition;
            animator.SetTrigger("ultimate");
            _bossReferences.ActualUltimateUses++;
        }
    }
}