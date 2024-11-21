using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeAttack : MonoBehaviour
{
    BossStats _bossStats;
    void Awake()
    {
        _bossStats = FindFirstObjectByType<BossStats>();

        Destroy(gameObject, _bossStats.MeleeAttackLifetime);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<CharacterHealthManager>()
            .PlayerRecieveDamage(_bossStats.MeleeAttackDamage * (1 + _bossStats.TotalDamage / 100));
        }
    }
}
