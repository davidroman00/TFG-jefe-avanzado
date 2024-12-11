using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUIHealManager : MonoBehaviour
{
    [SerializeField]
    Image _healGreyMask;
    [SerializeField]
    CharacterStats _characterStats;
    [SerializeField]
    CharacterCooldownManager _characterCooldownManager;
    void Update()
    {
        HandleGreyMask();
    }
    void HandleGreyMask()
    {
        //_healGreyMask.fillAmount = (Time.time - _characterCooldownManager.LastHeal) / _characterStats.HealCooldown;
    }
}
