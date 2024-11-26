using System.Collections;
using UnityEngine;

public class BossAnimationEvents : MonoBehaviour
{
    BossReferences _bossReferences;
    BossStats _bossStats;
    CharacterStats _characterStats;
    Animator _animator;
    BossCooldownManager _bossCooldownManager;
    int _currentSweepLoops;
    int _currentDefensiveBreakLoops;

    void Awake()
    {
        _bossReferences = GetComponent<BossReferences>();
        _bossStats = GetComponent<BossStats>();
        _characterStats = FindFirstObjectByType<CharacterStats>();
        _animator = GetComponent<Animator>();
        _bossCooldownManager = GetComponent<BossCooldownManager>();
    }

    //These are (mostly) public methods so they can be accessed through an animation event.
    public void MeleeAttackSpawn()
    {
        Instantiate(_bossReferences.MeleeAttackPrefab, _bossReferences.MeleeAttackSpawnPoint.position, _bossReferences.MeleeAttackSpawnPoint.rotation);
        _bossCooldownManager.LastMelee = Time.time;
    }
    public void FanProjectilesSpawn()
    {
        for (int i = 0; i < _bossReferences.FanProjectilesSpawnPoints.Length; i++)
        {
            Instantiate(_bossReferences.FanAndCrossProjectilePrefab, _bossReferences.FanProjectilesSpawnPoints[i].position, _bossReferences.FanProjectilesSpawnPoints[i].rotation);
        }
        _bossCooldownManager.LastFan = Time.time;
    }
    public void CrossProjectilesSpawn()
    {
        for (int i = 0; i < _bossReferences.CrossProjectilesSpawnPoints.Length; i++)
        {
            Instantiate(_bossReferences.FanAndCrossProjectilePrefab, _bossReferences.CrossProjectilesSpawnPoints[i].position, _bossReferences.CrossProjectilesSpawnPoints[i].rotation);
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
                break;
        }
    }
    void SweepProjectileSpawn1()
    {
        Instantiate(_bossReferences.SweepProjectilePrefab, /*_bossReferences.SweepProjectilesSpawnPoints[0].position*/new Vector3(_bossReferences.SweepProjectilesSpawnPoints[0].position.x, _bossReferences.SweepProjectilesSpawnPoints[0].position.y + 1.75f, _bossReferences.SweepProjectilesSpawnPoints[0].position.z), _bossReferences.SweepProjectilesSpawnPoints[0].rotation);
    }
    void SweepProjectileSpawn2()
    {
        Instantiate(_bossReferences.SweepProjectilePrefab, /*_bossReferences.SweepProjectilesSpawnPoints[1].position*/new Vector3(_bossReferences.SweepProjectilesSpawnPoints[1].position.x, _bossReferences.SweepProjectilesSpawnPoints[1].position.y + 1.75f, _bossReferences.SweepProjectilesSpawnPoints[1].position.z), _bossReferences.SweepProjectilesSpawnPoints[1].rotation);
    }
    void SweepProjectileSpawn3()
    {
        Instantiate(_bossReferences.SweepProjectilePrefab, /*_bossReferences.SweepProjectilesSpawnPoints[2].position*/ new Vector3(_bossReferences.SweepProjectilesSpawnPoints[2].position.x, _bossReferences.SweepProjectilesSpawnPoints[2].position.y + 1.75f, _bossReferences.SweepProjectilesSpawnPoints[2].position.z), _bossReferences.SweepProjectilesSpawnPoints[2].rotation);
    }
    public void CheckSweepBreak()
    {
        if (_currentSweepLoops >= 3)
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
            _currentSweepLoops = 0;
            _bossCooldownManager.LastSweep = Time.time;
        }
    }
    public IEnumerator ApplyBuff()
    {
        _bossStats.ArmorAmount += _bossStats.AmountOfArmorBuffed;
        _bossStats.HealthRegenerationAmount += _bossStats.AmountOfRegenerationBuffed;
        _bossStats.CooldownReductionAmount += _bossStats.AmountOfCooldownBuffed;
        _bossStats.TotalDamage += _bossStats.AmountOfDamageBuffed;
        _animator.SetFloat("animationSpeed", 1 + _bossStats.AmountOfAnimationSpeedBuffed / 100);
        _bossCooldownManager.LastBuff = Time.time;
        _bossReferences.BuffIcon.SetActive(true);
        _bossReferences.BuffParticleSystem.Play();

        yield return new WaitForSeconds(_bossStats.BuffDuration);
        RevertBuff();
    }
    void RevertBuff()
    {
        _bossStats.ArmorAmount -= _bossStats.AmountOfArmorBuffed;
        _bossStats.HealthRegenerationAmount -= _bossStats.AmountOfRegenerationBuffed;
        _bossStats.CooldownReductionAmount -= _bossStats.AmountOfCooldownBuffed;
        _bossStats.TotalDamage -= _bossStats.AmountOfDamageBuffed;
        _animator.SetFloat("animationSpeed", 1);
        _bossReferences.BuffIcon.SetActive(false);
    }
    public IEnumerator ApplyDebuff()
    {
        _characterStats.ArmorAmount -= _bossStats.AmountOfArmorDebuffed;
        _characterStats.TotalMovementSpeed -= _bossStats.AmountOfSpeedDebuffed;
        _characterStats.TotalDamage -= _bossStats.AmountOfDamageDebuffed;
        _bossCooldownManager.LastDebuff = Time.time;
        _bossReferences.DebuffIcon.SetActive(true);
        _bossReferences.DebuffParticleSystem.Play();

        yield return new WaitForSeconds(_bossStats.DebuffDuration);
        RevertDebuff();
    }
    void RevertDebuff()
    {
        _characterStats.ArmorAmount += _bossStats.AmountOfArmorDebuffed;
        _characterStats.TotalMovementSpeed += _bossStats.AmountOfSpeedDebuffed;
        _characterStats.TotalDamage += _bossStats.AmountOfDamageDebuffed;
        _bossReferences.DebuffIcon.SetActive(false);
    }
    public void ActualDodgeStart()
    {
        _bossReferences.IsActualDodgeActive = true;
    }
    public void ActualMidDodge()
    {
        _bossReferences.HasReachedMidDodge = true;
    }
    public void ActualDodgeEnd()
    {
        _bossReferences.IsActualDodgeActive = false;
    }
    public void TeleportToPosition()
    {
        transform.position = _bossReferences.ActualTeleportPosition.position;
        transform.rotation = _bossReferences.ActualTeleportPosition.rotation;
    }
    public void UltimateDeviceSpawn()
    {
        Instantiate(_bossReferences.UltimateDevicePrefab, _bossReferences.UltimateDeviceSpawnPoint.position, _bossReferences.UltimateDeviceSpawnPoint.rotation);
    }
    public void UltimateAttackStart()
    {
        Instantiate(_bossReferences.UltimateWeaponPrefab, _bossReferences.UltimateWeaponSpawnPoint.position, _bossReferences.UltimateWeaponSpawnPoint.rotation);
    }
    public void DefensiveBreakManager()
    {
        _currentDefensiveBreakLoops++;
        if (_currentDefensiveBreakLoops >= 5)
        {
            _animator.SetTrigger("ultimateBreakEnd");
            _animator.SetTrigger("sweepBreakEnd");
            _currentDefensiveBreakLoops = 0;
        }
    }
}
