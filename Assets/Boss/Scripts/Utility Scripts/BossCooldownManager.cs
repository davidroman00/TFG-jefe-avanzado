using UnityEngine;

public class BossCooldownManager : MonoBehaviour
{
    BossStats _bossStats;
    float _lastMelee;
    float _lastFanRanged;
    float _lastSweepRanged;
    float _lastCrossRanged;
    float _lastUltimate;
    float _lastBuff;
    float _lastDebuff;
    float _lastDodge;
    public float LastMelee { set { _lastMelee = value; } }
    public float LastFanRanged { set { _lastFanRanged = value; } }
    public float LastSweepRanged { set { _lastSweepRanged = value; } }
    public float LastCrossRanged { set { _lastCrossRanged = value; } }
    public float LastUltimate { set { _lastUltimate = value; } }
    public float LastBuff { set { _lastBuff = value; } }
    public float LastDebuff { set { _lastDebuff = value; } }
    public float LastDodge { set { _lastDodge = value; } }
    void Awake()
    {
        _bossStats = GetComponent<BossStats>();
    }
    public bool IsMeleeOnCooldown()
    {
        return Time.time < _lastMelee + _bossStats.MeleeCooldown;
    }
    public bool IsFanOnCooldown()
    {
        return Time.time < _lastFanRanged + _bossStats.FanRangedCooldown;
    }
    public bool IsSweepOnCooldown()
    {
        return Time.time < _lastSweepRanged + _bossStats.SweepRangedCooldown;
    }
    public bool IsCrossOnCooldown()
    {
        return Time.time < _lastCrossRanged + _bossStats.CrossRangedCooldown;
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
    public bool IsDodgeOnCooldown()
    {
        return Time.time < _lastDodge + _bossStats.DodgeCooldown;
    }
}
