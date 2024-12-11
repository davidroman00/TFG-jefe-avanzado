using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{
    CharacterMeleeWeapon _characterMeleeWeapon;
    CharacterReferences _characterReferences;
    void Awake()
    {
        _characterMeleeWeapon = GetComponentInChildren<CharacterMeleeWeapon>();
        _characterReferences = GetComponent<CharacterReferences>();
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
    public void ActualDashStart()
    {
        _characterReferences.IsActualDashActive = true;
    }
    public void ActualDashEnd()
    {
        _characterReferences.IsActualDashActive = false;
    }
}