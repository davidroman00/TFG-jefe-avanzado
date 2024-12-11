using UnityEngine;

public class BossHealthManager : MonoBehaviour
{
    BossStats _bossStats;
    BossReferences _bossReferences;

    void Start()
    //Usually, you want to initialize scripts in the Awake() method.
    //However, due to Unity's execution order, you need to use the Start() method here, so it doesn't crash.
    {
        _bossStats = GetComponentInParent<BossStats>();
        _bossReferences = GetComponentInParent<BossReferences>();
        _bossReferences.BossUIHealthManager.SetMaxHealth(_bossStats.MaxHP);
        _bossReferences.BossUIHealthManager.SetCurrentHealth(_bossStats.CurrentHP);
    }
    void Update()
    {
        if (_bossStats.HealthRegenerationAmount > 0)
        {
            BossRegenerateHealt();
        }
        if (_bossStats.CurrentHP <= 0)
        {
            GetComponentInParent<Animator>().SetTrigger("death");
        }
    }
    public void BossRecieveDamage(float value)
    {
        if (value > 0)
        {
            _bossStats.CurrentHP -= value - _bossStats.ArmorAmount;
        }
        else
        {
            _bossStats.CurrentHP -= value;
        }
        _bossReferences.BossUIHealthManager.SetCurrentHealth(_bossStats.CurrentHP);
    }
    void BossRegenerateHealt()
    {
        _bossStats.CurrentHP += _bossStats.HealthRegenerationAmount * Time.deltaTime;
    }
}
