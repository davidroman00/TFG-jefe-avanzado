using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCooldownManager : MonoBehaviour
{
    CharacterStats _characterStats;
    float _lastHeal;
    float _lastStagger;
    public float LastHeal { set { _lastHeal = value; } }
    public float LastStagger { set { _lastStagger = value; } }
    void Awake()
    {
        _characterStats = GetComponent<CharacterStats>();
    }
    public bool IsHealOnCooldown()
    {
        return Time.time < _lastHeal + _characterStats.HealCooldown;
    }
    public bool IsStaggerOnCooldown()
    {
        return Time.time < _lastStagger + _characterStats.StaggerCooldown;
    }
}
