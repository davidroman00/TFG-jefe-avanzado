using System.Collections;
using UnityEngine;

public class BossAnimationEvents : MonoBehaviour
{
    BossReferences _bossReferences;
    BossStats _bossStats;
    CharacterStats _characterStats;
    Animator _animator;
    int _currentUltimateBreakLoops;

    void Awake()
    {
        _bossReferences = GetComponent<BossReferences>();
        _bossStats = GetComponent<BossStats>();
        _characterStats = FindFirstObjectByType<CharacterStats>();
        _animator = GetComponent<Animator>();
    }

    //These are (mostly) public methods so they can be accessed through an animation event.
    public void MeleeAttackSpawn()
    {
        Instantiate(_bossReferences.MeleeAttackPrefab, _bossReferences.MeleeAttackSpawnPoint.position, _bossReferences.MeleeAttackSpawnPoint.rotation);
    }
    public void FanProjectilesSpawn()
    {
        for (int i = 0; i < _bossReferences.FanProjectilesSpawnPoints.Length; i++)
        {
            Instantiate(_bossReferences.FanAndCrossProjectilePrefab, _bossReferences.FanProjectilesSpawnPoints[i].position, _bossReferences.FanProjectilesSpawnPoints[i].rotation);
        }
    }
    public void CrossProjectilesSpawn()
    {
        for (int i = 0; i < _bossReferences.CrossProjectilesSpawnPoints.Length; i++)
        {
            Instantiate(_bossReferences.FanAndCrossProjectilePrefab, _bossReferences.CrossProjectilesSpawnPoints[i].position, _bossReferences.CrossProjectilesSpawnPoints[i].rotation);
        }
    }
    public void SweepProjectilesSpawn()
    {
        for (int i = 0; i < _bossReferences.SweepProjectilesSpawnPoints.Length; i++)
        {
            Instantiate(_bossReferences.SweepProjectilePrefab, _bossReferences.SweepProjectilesSpawnPoints[i].position, _bossReferences.SweepProjectilesSpawnPoints[i].rotation);
        }
    }
    public void CheckSweepBreak()
    {
        for (int i = 0; i < _bossReferences.SweepProjectilesSpawnPoints.Length; i++)
        {
            if (i >= _bossReferences.SweepProjectilesSpawnPoints.Length)
            {
                _bossReferences.ActualTeleportPosition = _bossReferences.CrossBossPosition;
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
