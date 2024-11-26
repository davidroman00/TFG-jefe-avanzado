using UnityEngine;

public class BossCooldownManager : MonoBehaviour
{
    BossStats _bossStats;
    float _lastMelee = -5;
    float _lastFan = 15;
    float _lastSweep = 45;
    float _lastCross = 30;
    float _lastUltimate;
    float _lastBuff;
    float _lastDebuff = 60;
    float _lastDodge = -100;

    public float LastMelee { set { _lastMelee = value; } }
    public float LastFan { set { _lastFan = value; } }
    public float LastSweep { set { _lastSweep = value; } }
    public float LastCross { set { _lastCross = value; } }
    public float LastUltimate { set { _lastUltimate = value; } }
    public float LastBuff { get { return _lastBuff; } set { _lastBuff = value; } }
    public float LastDebuff { get { return _lastDebuff; } set { _lastDebuff = value; } }
    public float LastDodge { set { _lastDodge = value; } }
    void Awake()
    {
        _bossStats = GetComponent<BossStats>();
    }
    public bool IsMeleeOnCooldown()
    {
        return Time.time < _lastMelee + _bossStats.MeleeCooldown * (1 - _bossStats.CooldownReductionAmount / 100);
    }
    public bool IsFanOnCooldown()
    {
        return Time.time < _lastFan + _bossStats.FanRangedCooldown * (1 - _bossStats.CooldownReductionAmount / 100);
    }
    public bool IsSweepOnCooldown()
    {
        return Time.time < _lastSweep + _bossStats.SweepRangedCooldown * (1 - _bossStats.CooldownReductionAmount / 100);
    }
    public bool IsCrossOnCooldown()
    {
        return Time.time < _lastCross + _bossStats.CrossRangedCooldown * (1 - _bossStats.CooldownReductionAmount / 100);
    }
    public bool IsUltimateOnCooldown()
    {
        return Time.time < _lastUltimate + _bossStats.UltimateCooldown * (1 - _bossStats.CooldownReductionAmount / 100);
    }
    public bool IsBuffOnCooldown()
    {
        return Time.time < _lastBuff + _bossStats.BuffCooldown * (1 - _bossStats.CooldownReductionAmount / 100);
    }
    public bool IsDebuffOnCooldown()
    {
        return Time.time < _lastDebuff + _bossStats.DebuffCooldown * (1 - _bossStats.CooldownReductionAmount / 100);
    }
    public bool IsDodgeOnCooldown()
    {
        return Time.time < _lastDodge + _bossStats.DodgeCooldown * (1 - _bossStats.CooldownReductionAmount / 100);
    }
}
