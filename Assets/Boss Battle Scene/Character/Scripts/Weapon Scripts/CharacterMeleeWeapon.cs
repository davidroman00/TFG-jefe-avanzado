using UnityEngine;

public class CharacterMeleeWeapon : MonoBehaviour
{
    CharacterStats _characterStats;
    void Awake()
    {
        _characterStats = GetComponentInParent<CharacterStats>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<BossHealthManager>() && enabled)
        {
            collider.GetComponent<BossHealthManager>().BossRecieveDamage(_characterStats.MeleeAttacksDamage[0] * (1 + _characterStats.TotalDamageBonus / 100));
            enabled = false;
            //Disabling this script is necessary in order to deal damage only once per attack.
            //This is enabled through animation events, check the script 'CharacterAnimationEvents.cs' and the relative animation to learn more.
        }
    }
}