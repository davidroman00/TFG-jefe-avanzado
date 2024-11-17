using UnityEngine;

public class BossAnimationEvents : MonoBehaviour
{
    BossReferences _bossReferences;
    BossStats _bossStats;
    CharacterStats _characterStats;
    Animator _animator;
    float _lastBuff;
    bool _isBuffActive;
    float _lastDebuff;
    bool _isDebuffActive;
    int _currentUltimateBreakLoops;
    void Awake()
    {
        _bossReferences = GetComponent<BossReferences>();
        _bossStats = GetComponent<BossStats>();
        _characterStats = FindFirstObjectByType<CharacterStats>();
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (_isBuffActive)
        {
            CheckBuffDuration();
        }
        if (_isDebuffActive)
        {
            CheckDebuffDuration();
        }
    }
    //These are (mostly) public methods so they can be accessed through an animation event.
    public void MeleeAttackSpawn()
    {
        Instantiate(_bossReferences.MeleeAttackDevice, _bossReferences.MeleeAttackSpawnPoint.position, _bossReferences.MeleeAttackSpawnPoint.rotation);
    }
    public void FanProjectilesSpawn()
    {
        for (int i = 0; i < _bossReferences.FanRangedSpawnPoints.Length; i++)
            Instantiate(_bossReferences.FanAndCrossRangedProjectile, _bossReferences.FanRangedSpawnPoints[i].position, _bossReferences.FanRangedSpawnPoints[i].rotation);
    }
    public void CrossProjectilesSpawn()
    {
        for (int i = 0; i < _bossReferences.CrossRangedSpawnPoints.Length; i++)
            Instantiate(_bossReferences.FanAndCrossRangedProjectile, _bossReferences.CrossRangedSpawnPoints[i].position, _bossReferences.CrossRangedSpawnPoints[i].rotation);
    }
    public void SweepProjectilesSpawn()
    {
        for (int i = 0; i < _bossReferences.SweepRangedSpawnPoints.Length; i++)
        {
            Instantiate(_bossReferences.SweepRangedProjectile, _bossReferences.SweepRangedSpawnPoints[i].position, _bossReferences.SweepRangedSpawnPoints[i].rotation);
            if (i == _bossReferences.CrossRangedSpawnPoints.Length)
            {
                if (_characterStats.IsSweepBreak)
                {
                    _animator.SetTrigger("sweepBreak");
                }
                else
                {
                    _animator.SetTrigger("notSweepBreak");
                }
                _characterStats.IsSweepBreak = false;
            }
        }

    }
    public void ApplyBuff()
    {
        _bossStats.ArmorAmount += _bossStats.AmountOfArmorBuffed;
        _bossStats.HealthRegenerationAmount += _bossStats.AmountOfRegenerationBuffed;
        _bossStats.CooldownReductionAmount += _bossStats.AmountOfCooldownBuffed;
        _bossStats.TotalDamage += _bossStats.AmountOfDamageBuffed;

        _lastBuff = Time.time;
        _isBuffActive = true;
    }
    void CheckBuffDuration()
    {
        if (Time.time < _lastBuff + _bossStats.BuffDuration)
        {
            _bossStats.ArmorAmount -= _bossStats.AmountOfArmorBuffed;
            _bossStats.HealthRegenerationAmount -= _bossStats.AmountOfRegenerationBuffed;
            _bossStats.CooldownReductionAmount -= _bossStats.AmountOfCooldownBuffed;
            _bossStats.TotalDamage -= _bossStats.AmountOfDamageBuffed;

            _isBuffActive = false;
        }

    }
    public void ApplyDebuff()
    {
        _characterStats.ArmorAmount -= _bossStats.AmountOfArmorDebuffed;
        _characterStats.MovementSpeed -= _bossStats.AmountOfSpeedDebuffed;
        _characterStats.TotalDamage -= _bossStats.AmountOfDamageDebuffed;

        _lastDebuff = Time.time;
        _isDebuffActive = true;
    }
    void CheckDebuffDuration()
    {
        if (Time.time < _lastBuff + _bossStats.DebuffDuration)
        {
            _characterStats.ArmorAmount += _bossStats.AmountOfArmorDebuffed;
            _characterStats.MovementSpeed += _bossStats.AmountOfSpeedDebuffed;
            _characterStats.TotalDamage += _bossStats.AmountOfDamageDebuffed;

            _isDebuffActive = false;
        }
    }
    public void TeleportToPosition()
    {
        transform.position = _bossReferences.ActualTeleportPosition.position;
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
