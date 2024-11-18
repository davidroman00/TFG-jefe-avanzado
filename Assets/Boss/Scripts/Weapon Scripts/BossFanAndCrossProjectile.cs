
using UnityEngine;

public class BossFanAndCrossProjectile : MonoBehaviour
{
    BossStats _bossStats;
    void Awake()
    {
        _bossStats = FindFirstObjectByType<BossStats>();

        Destroy(gameObject, _bossStats.CrossAndFanProjectileLifetime);
    }
    void Update()
    {
        HandleProjectileMovement();
    }
    void HandleProjectileMovement()
    {
        transform.Translate(_bossStats.FanAndCrossProjectileMovementSpeed * Time.deltaTime * Vector3.forward);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<CharacterHealthManager>()
            .PlayerRecieveDamage(_bossStats.FanAndCrossProjectileDamage * 1 + (_bossStats.TotalDamage / 100));
            
            Destroy(gameObject);
        }
    }
}
