using UnityEngine;

public class BossStats : MonoBehaviour
{
   //Here, there are stored every variable relative to the boss statistics.
   //The fact that there are some values at 0 on inspector means they are not necessary for the current phase of the boss.
   [SerializeField]
   float _armorAmount;
   [SerializeField]
   float _healthRegenerationAmount;
   [SerializeField]
   float _cooldownReductionAmount;
   [SerializeField]
   float _totalDamageBuff;
   [SerializeField]
   float _meleeAttackDamage;
   [SerializeField]
   float _fanProjectileDamage;
   [SerializeField]
   float _sweepProjectileDamage;
   [SerializeField]
   float _crossProjectileDamage;
   [SerializeField]
   float _ultimateAttackDamage;
   [SerializeField]
   float _crossAndFanProjectileLifetime;
   [SerializeField]
   float _sweepProjectileLifetime;
   [SerializeField]
   float _meleeCooldown;
   [SerializeField]
   float _fanRangedCooldown;
   [SerializeField]
   float _sweepRangedCooldown;
   [SerializeField]
   float _crossRangedCooldown;
   [SerializeField]
   float _dashCooldown;
   [SerializeField]
   float _ultimateCooldown;
   [SerializeField]
   float _buffCooldown;
   [SerializeField]
   float _debuffCooldown;
   [SerializeField]
   float _buffDuration;
   [SerializeField]
   float _debuffDuration;
   [SerializeField]
   float _amountOfArmorBuffed;
   [SerializeField]
   float _amountOfRegenerationBuffed;
   [SerializeField]
   float _amountOfDamageBuffed;
   [SerializeField]
   float _amountOfCooldownBuffed;
   [SerializeField]
   float _amountOfDamageDebuffed;
   [SerializeField]
   float _amountOfSpeedDebuffed;
   [SerializeField]
   float _amountOfArmorDebuffed;
   [SerializeField]
   float _meleeMaxDistance;
   [SerializeField]
   float _dashMovementSpeed;
   [SerializeField]
   float _fanAndCrossProjectileMovementSpeed;
   [SerializeField]
   float _sweepProjectileMovementSpeed;
   [SerializeField]
   float _bossMovementSpeed;
   [SerializeField]
   int _bossMaxUltimateUses;
   [SerializeField]
   float _bossUltimateHPThreshold;
   [SerializeField]
   float _bossMaxHP;
   bool _isActualDashActive;
   bool _isOutsideArena;

   //This section is in charge of exporting every variable in ReadOnly, thanks to the getter.
   //If you want to modify these variables dynamically, you need a setter instead.
   public float ArmorAmount { get { return _armorAmount; } set { _armorAmount = value; } }
   public float HealthRegenerationAmount { get { return _healthRegenerationAmount; } set { _healthRegenerationAmount = value; } }
   public float CooldownReductionAmount { get { return _cooldownReductionAmount; } set { _cooldownReductionAmount = value; } }
   public float TotalDamageBuff { get { return _totalDamageBuff; } }
   public float SimpleMeleeAttackDamage { get { return _meleeAttackDamage; } }
   public float FanProjectileDamage { get { return _fanProjectileDamage; } }
   public float SweepProjectileDamage { get { return _sweepProjectileDamage; } }
   public float CrossProjectileDamage { get { return _crossProjectileDamage; } }
   public float UltimateAttackDamage { get { return _ultimateAttackDamage; } }
   public float CrossAndFanProjectileLifetime { get { return _crossAndFanProjectileLifetime; } }
   public float SweepProjectileLifetime { get { return _sweepProjectileLifetime; } }
   public float MeleeCooldown { get { return _meleeCooldown; } }
   public float FanRangedCooldown { get { return _fanRangedCooldown; } }
   public float SweepRangedCooldown { get { return _sweepRangedCooldown; } }
   public float CrossRangedCooldown { get { return _crossRangedCooldown; } }
   public float DashCooldown { get { return _dashCooldown; } }
   public float UltimateCooldown { get { return _ultimateCooldown; } }
   public float BuffCooldown { get { return _buffCooldown; } }
   public float DebuffCooldown { get { return _debuffCooldown; } }
   public float BuffDuration { get { return _buffDuration; } }
   public float DebuffDuration { get { return _debuffDuration; } }
   public float AmountOfArmorBuffed { get { return _amountOfArmorBuffed; } }
   public float AmountOfRegenerationBuffed { get { return _amountOfRegenerationBuffed; } }
   public float AmountOfDamageBuffed { get { return _amountOfDamageBuffed; } }
   public float AmountOfCooldownBuffed { get { return _amountOfCooldownBuffed; } }
   public float AmountOfDamageDebuffed { get { return _amountOfDamageDebuffed; } }
   public float AmountOfSpeedDebuffed { get { return _amountOfSpeedDebuffed; } }
   public float AmountOfArmorDebuffed { get { return _amountOfArmorDebuffed; } }
   public float MeleeMaxDistance { get { return _meleeMaxDistance; } }
   public float DashMovementSpeed { get { return _dashMovementSpeed; } }
   public float FanAndCrossProjectileMovementSpeed { get { return _fanAndCrossProjectileMovementSpeed; } }
   public float SweepProjectileMovementSpeed { get { return _sweepProjectileMovementSpeed; } }
   public float BossMovementSpeed { get { return _bossMovementSpeed; } }
   public int BossMaxUltimateUses { get { return _bossMaxUltimateUses; } }
   public float BossUltimateHPThreshold { get { return _bossUltimateHPThreshold; } }
   public float BossMaxHP { get { return _bossMaxHP; } }
   public bool IsActualDashActive { get { return _isActualDashActive; } set { _isActualDashActive = value; } }
   public bool IsOutsideArena { get { return _isOutsideArena; } set { _isOutsideArena = value; } }
}