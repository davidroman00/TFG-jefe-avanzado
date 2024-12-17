using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSweepProjectile : MonoBehaviour
{
    BossStats _bossStats;
    void Awake()
    {
        _bossStats = FindFirstObjectByType<BossStats>();

        Destroy(gameObject, _bossStats.SweepProjectileLifetime);
    }
    void Update()
    {
        HandleProjectileMovement();
    }
    void HandleProjectileMovement()
    {
        transform.Translate(_bossStats.SweepProjectileMovementSpeed * Time.deltaTime * Vector3.forward);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<CharacterHealthManager>()
            .CharacterModifyCurrentHealth(_bossStats.SweepProjectileDamage * (1 + _bossStats.TotalDamage / 100));
        }
    }
}
