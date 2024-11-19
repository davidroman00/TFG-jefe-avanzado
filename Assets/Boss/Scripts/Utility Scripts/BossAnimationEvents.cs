using System.Collections;
using UnityEngine;

public class BossAnimationEvents : MonoBehaviour
{
    BossReferences _bossReferences;
    BossStats _bossStats;
    BossCooldownManager _bossCooldownManager;
    CharacterStats _characterStats;
    Animator _animator;
    int _currentUltimateBreakLoops;

    void Awake()
    {
        _bossReferences = GetComponent<BossReferences>();
        _bossStats = GetComponent<BossStats>();
        _bossCooldownManager = GetComponent<BossCooldownManager>();
        _characterStats = FindFirstObjectByType<CharacterStats>();
        _animator = GetComponent<Animator>();
    }
    void Update(){Debug.Log(_bossStats.ArmorAmount);}
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
        for (int i = 0; i < _bossReferences.SweepRangedSpawnPoints.Length; i++)
        {
            Instantiate(_bossReferences.SweepProjectilePrefab, _bossReferences.SweepRangedSpawnPoints[i].position, _bossReferences.SweepRangedSpawnPoints[i].rotation);
        }
        _bossCooldownManager.LastSweep = Time.time;
    }
    public void CheckSweepBreak()
    {
        for (int i = 0; i < _bossReferences.SweepRangedSpawnPoints.Length; i++)
        {
            if (i >= _bossReferences.SweepRangedSpawnPoints.Length)
            {
                if (_characterStats.IsSweepBreak)
                {
                    _animator.SetTrigger("sweepBreak");
                }
                else
                {
                    _animator.SetTrigger("notSweepBreak");
                }
            }
        }
        _characterStats.IsSweepBreak = false;
    }
    public IEnumerator ApplyBuff()
    {
        _bossStats.ArmorAmount += _bossStats.AmountOfArmorBuffed;
        _bossStats.HealthRegenerationAmount += _bossStats.AmountOfRegenerationBuffed;
        _bossStats.CooldownReductionAmount += _bossStats.AmountOfCooldownBuffed;
        _bossStats.TotalDamage += _bossStats.AmountOfDamageBuffed;

        _bossCooldownManager.LastBuff = Time.time;

        yield return new WaitForSeconds(_bossStats.BuffDuration);
        RevertBuff();
    }
    void RevertBuff()
    {
        _bossStats.ArmorAmount -= _bossStats.AmountOfArmorBuffed;
        _bossStats.HealthRegenerationAmount -= _bossStats.AmountOfRegenerationBuffed;
        _bossStats.CooldownReductionAmount -= _bossStats.AmountOfCooldownBuffed;
        _bossStats.TotalDamage -= _bossStats.AmountOfDamageBuffed;
    }
    public IEnumerator ApplyDebuff()
    {
        _characterStats.ArmorAmount -= _bossStats.AmountOfArmorDebuffed;
        _characterStats.MovementSpeed -= _bossStats.AmountOfSpeedDebuffed;
        _characterStats.TotalDamage -= _bossStats.AmountOfDamageDebuffed;

        _bossCooldownManager.LastDebuff = Time.time;
        yield return new WaitForSeconds(_bossStats.DebuffDuration);
        RevertDebuff();
    }
    void RevertDebuff()
    {
        _characterStats.ArmorAmount += _bossStats.AmountOfArmorDebuffed;
        _characterStats.MovementSpeed += _bossStats.AmountOfSpeedDebuffed;
        _characterStats.TotalDamage += _bossStats.AmountOfDamageDebuffed;
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
