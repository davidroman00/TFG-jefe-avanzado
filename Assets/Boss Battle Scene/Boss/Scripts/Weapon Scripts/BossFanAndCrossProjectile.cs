
using UnityEngine;

public class BossFanAndCrossProjectile : MonoBehaviour
{
    BossStats _bossStats;
    float _projectileSpeed;
    void Awake()
    {
        _bossStats = FindFirstObjectByType<BossStats>();
        _projectileSpeed = _bossStats.FanAndCrossProjectileMovementSpeed;

        Destroy(gameObject, _bossStats.FanAndCrossProjectileLifetime);
    }
    void Update()
    {
        HandleProjectileMovement();
    }
    void HandleProjectileMovement()
    {
        transform.Translate(_projectileSpeed * Time.deltaTime * Vector3.forward);
        _projectileSpeed -= _bossStats.FanAndCrossProjectileDecelarationSpeed * Time.deltaTime;
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<CharacterHealthManager>()
            .PlayerRecieveDamage(_bossStats.FanAndCrossProjectileDamage * (1 + _bossStats.TotalDamage / 100));

            Destroy(gameObject);
        }
    }
}
