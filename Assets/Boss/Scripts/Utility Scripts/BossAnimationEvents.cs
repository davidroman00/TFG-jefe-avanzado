using UnityEngine;

public class BossAnimationEvents : MonoBehaviour
{
    BossReferences _bossReferences;
    BossStats _bossStats;
    BossCooldownManager _bossCooldownManager;
    CharacterStats _characterStats;
    Animator _animator;
    int _currentSweepLoops;
    int _currentUltimateBreakLoops;
    void Awake()
    {
        _bossReferences = GetComponent<BossReferences>();
        _bossStats = GetComponent<BossStats>();
        _bossCooldownManager = GetComponent<BossCooldownManager>();
        _characterStats = FindFirstObjectByType<CharacterStats>();
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (_bossCooldownManager.IsBuffActive())
        {
            CheckBuffDuration();
        }
        if (_bossCooldownManager.IsDebuffActive())
        {
            CheckDebuffDuration();
        }
    }
    //These are (mostly) public methods so they can be accessed through an animation event.
    public void MeleeAttackSpawn()
    {
        Instantiate(_bossReferences.MeleeAttackPrefab, _bossReferences.MeleeAttackSpawnPoint.position, _bossReferences.MeleeAttackSpawnPoint.rotation);
        _bossCooldownManager.LastMelee = Time.time;
    }
    public void FanProjectilesSpawn()
    {
        for (int i = 0; i < _bossReferences.FanRangedSpawnPoints.Length; i++)
        {
            Instantiate(_bossReferences.FanAndCrossProjectilePrefab, _bossReferences.FanRangedSpawnPoints[i].position, _bossReferences.FanRangedSpawnPoints[i].rotation);
        }
        _bossCooldownManager.LastFan = Time.time;
    }
    public void CrossProjectilesSpawn()
    {
        for (int i = 0; i < _bossReferences.CrossRangedSpawnPoints.Length; i++)
        {
            Instantiate(_bossReferences.FanAndCrossProjectilePrefab, _bossReferences.CrossRangedSpawnPoints[i].position, _bossReferences.CrossRangedSpawnPoints[i].rotation);
        }
        _bossCooldownManager.LastCross = Time.time;
    }
    public void SweepProjectilesSpawn()
    {
        _currentSweepLoops++;
        switch (_currentSweepLoops)
        {
            case 1:
                SweepProjectileSpawn1();
                break;
            case 2:
                SweepProjectileSpawn2();
                break;
            case 3:
                SweepProjectileSpawn3();
                if (_characterStats.IsSweepBreak)
                {
                    _animator.SetTrigger("sweepBreak");
                }
                else
                {
                    _animator.SetTrigger("notSweepBreak");
                }
                _currentSweepLoops = 0;
                _characterStats.IsSweepBreak = false;
                break;
        }
        _bossCooldownManager.LastSweep = Time.time;
    }
    void SweepProjectileSpawn1()
    {
        Instantiate(_bossReferences.SweepProjectilePrefab, _bossReferences.SweepRangedSpawnPoints[0].position, _bossReferences.SweepRangedSpawnPoints[0].rotation);
    }
    void SweepProjectileSpawn2()
    {
        Instantiate(_bossReferences.SweepProjectilePrefab, _bossReferences.SweepRangedSpawnPoints[1].position, _bossReferences.SweepRangedSpawnPoints[1].rotation);
    }
    void SweepProjectileSpawn3()
    {
        Instantiate(_bossReferences.SweepProjectilePrefab, _bossReferences.SweepRangedSpawnPoints[2].position, _bossReferences.SweepRangedSpawnPoints[2].rotation);
    }
    public void ApplyBuff()
    {
        _bossStats.ArmorAmount += _bossStats.AmountOfArmorBuffed;
        _bossStats.HealthRegenerationAmount += _bossStats.AmountOfRegenerationBuffed;
        _bossStats.CooldownReductionAmount += _bossStats.AmountOfCooldownBuffed;
        _bossStats.TotalDamage += _bossStats.AmountOfDamageBuffed;

        _bossCooldownManager.LastBuff = Time.time;
    }
    void CheckBuffDuration()
    {
        if (!_bossCooldownManager.IsBuffActive())
        {
            _bossStats.ArmorAmount -= _bossStats.AmountOfArmorBuffed;
            _bossStats.HealthRegenerationAmount -= _bossStats.AmountOfRegenerationBuffed;
            _bossStats.CooldownReductionAmount -= _bossStats.AmountOfCooldownBuffed;
            _bossStats.TotalDamage -= _bossStats.AmountOfDamageBuffed;
        }

    }
    public void ApplyDebuff()
    {
        _characterStats.ArmorAmount -= _bossStats.AmountOfArmorDebuffed;
        _characterStats.MovementSpeed -= _bossStats.AmountOfSpeedDebuffed;
        _characterStats.TotalDamage -= _bossStats.AmountOfDamageDebuffed;

        _bossCooldownManager.LastDebuff = Time.time;
    }
    void CheckDebuffDuration()
    {
        if (!_bossCooldownManager.IsDebuffActive())
        {
            _characterStats.ArmorAmount += _bossStats.AmountOfArmorDebuffed;
            _characterStats.MovementSpeed += _bossStats.AmountOfSpeedDebuffed;
            _characterStats.TotalDamage += _bossStats.AmountOfDamageDebuffed;
        }
    }
    public void TeleportToPosition()
    {
        transform.position = _bossReferences.ActualTeleportPosition.position;
    }
    public void UltimateDeviceSpawn()
    {
        Instantiate(_bossReferences.UltimateDevicePrefab, _bossReferences.UltimateDeviceSpawnPoint.position, _bossReferences.UltimateDeviceSpawnPoint.rotation);
        _bossCooldownManager.LastUltimate = Time.time;
    }
    public void UltimateAttackStart()
    {
        Instantiate(_bossReferences.UltimateWeaponPrefab, _bossReferences.UltimateWeaponSpawnPoint.position, _bossReferences.UltimateWeaponSpawnPoint.rotation);
    }
    public void UltimateBreakManager()
    {
        _currentUltimateBreakLoops++;
        if (_currentUltimateBreakLoops >= 5)
        {
            _animator.SetTrigger("ultimateBreakEnd");
            _currentUltimateBreakLoops = 0;
        }
    }
}
