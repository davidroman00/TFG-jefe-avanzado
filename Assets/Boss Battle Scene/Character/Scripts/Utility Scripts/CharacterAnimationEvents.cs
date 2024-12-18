using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{
    CharacterMeleeWeapon _characterMeleeWeapon;
    CharacterReferences _characterReferences;
    CharacterStats _characterStats;
    void Awake()
    {
        _characterMeleeWeapon = GetComponentInChildren<CharacterMeleeWeapon>();
        _characterReferences = GetComponent<CharacterReferences>();
        _characterStats = GetComponent<CharacterStats>();
    }
    //These are public methods so they can be accessed through an animation event
    public void OnAttackStart()
    {
        _characterMeleeWeapon.enabled = true;
    }
    public void OnAttackMid()
    {
        _characterMeleeWeapon.enabled = false;
    }
    public void ActualDodgeStart()
    {
        _characterReferences.IsActualDodgeActive = true;
    }
    public void HasReachedMidDodge()
    {
        _characterReferences.HasReachedMidDodge = true;
    }
    public void ActualDodgeEnd()
    {
        _characterReferences.IsActualDodgeActive = false;
    }
    public void ActualHeal()
    {
        _characterStats.HealCharges--;
        GetComponent<CharacterHealthManager>().CharacterModifyCurrentHealth(_characterStats.HealAmount);
    }
}