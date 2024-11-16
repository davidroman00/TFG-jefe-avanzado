using UnityEngine;

public class BossCooldownManager : MonoBehaviour
{
    BossStats _bossStats;
    float _lastMelee;
    float _lastFanRanged;
    float _lastSweepRanged;
    float _lastCrossRanged;
    float _lastDash;
    float _lastUltimate;
    float _lastBuff;
    float _lastDebuff;
    public float LastMelee { set { _lastMelee = value; } }
    public float LastFanRanged { set { _lastFanRanged = value; } }
    public float LastSweepRanged { set { _lastSweepRanged = value; } }
    public float LastCrossRanged { set { _lastCrossRanged = value; } }
    public float LastSimpleDash { set { _lastDash = value; } }
    public float LastUltimate { set { _lastUltimate = value; } }
    public float LastBuff { set { _lastBuff = value; } }
    public float LastDebuff { set { _lastDebuff = value; } }
    void Awake()
    {
        _bossStats = GetComponent<BossStats>();
    }
    public bool IsMeleeOnCooldown()
    {
        return Time.time < _lastMelee + _bossStats.MeleeCooldown;
    }
    public bool IsFanRangedOnCooldown()
    {
        return Time.time < _lastFanRanged + _bossStats.FanRangedCooldown;
    }
    public bool IsSweepRangedOnCooldown()
    {
        return Time.time < _lastSweepRanged + _bossStats.SweepRangedCooldown;
    }
    public bool IsCrossRangedOnCooldown()
    {
        return Time.time < _lastCrossRanged + _bossStats.CrossRangedCooldown;
    }
    public bool IsDashOnCooldown()
    {
        return Time.time < _lastDash + _bossStats.DashCooldown;
    }
    public bool IsUltimateOnCooldown()
    {
        return Time.time < _lastUltimate + _bossStats.UltimateCooldown;
    }
    public bool IsBuffOnCooldown()
    {
        return Time.time < _lastBuff + _bossStats.BuffCooldown;
    }
    public bool IsDebuffOnCooldown()
    {
        return Time.time < _lastDebuff + _bossStats.DebuffCooldown;
    }
}
