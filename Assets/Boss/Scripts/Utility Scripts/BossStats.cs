using Unity.VisualScripting;
using UnityEngine;

public class BossStats : MonoBehaviour
{
   //Here, there are stored every variable relative to the boss statistics.
   //The fact that there are some values at 0 on inspector means they are not necessary for the current phase of the boss.
   [Header("Boss global combat stats")]
   [SerializeField]
   float _bossMaxHP;
   [SerializeField]
   float _armorAmount;
   [SerializeField]
   float _healthRegenerationAmount;
   [SerializeField]
   float _cooldownReductionAmount;
   [SerializeField]
   float _totalDamage;

   [Header("Boss skill damage stats")]
   [SerializeField]
   float _meleeAttackDamage;
   [SerializeField]
   float _fanAndCrossProjectileDamage;
   [SerializeField]
   float _sweepProjectileDamage;
   [SerializeField]
   float _ultimateAttackDamage;

   [Header("Boss skill cooldown stats")]
   [SerializeField]
   float _meleeCooldown;
   [SerializeField]
   float _fanRangedCooldown;
   [SerializeField]
   float _sweepRangedCooldown;
   [SerializeField]
   float _crossRangedCooldown;
   [SerializeField]
   float _buffCooldown;
   [SerializeField]
   float _debuffCooldown;
   [SerializeField]
   float _dodgeCooldown;
   [SerializeField]
   float _ultimateCooldown;

   [Header("Boss movement speed stats")]
   [SerializeField]
   float _fanAndCrossProjectileMovementSpeed;
   [SerializeField]
   float _fanAndCrossProjectileDecelerationSpeed;
   [SerializeField]
   float _sweepProjectileMovementSpeed;
   [SerializeField]
   float _dodgeMovementSpeed;

   [Header("Boss projectiles lifetime stats")]
   [SerializeField]
   float _fanAndCrossProjectileLifetime;
   [SerializeField]
   float _sweepProjectileLifetime;
   [SerializeField]
   float _meleeAttackLifetime;

   [Header("Boss buff related stats")]
   [SerializeField]
   float _buffDuration;
   [SerializeField]
   float _amountOfArmorBuffed;
   [SerializeField]
   float _amountOfRegenerationBuffed;
   [SerializeField]
   float _amountOfDamageBuffed;
   [SerializeField]
   float _amountOfCooldownBuffed;
   [SerializeField]
   float _amountOfAnimationSpeedBuffed;

   [Header("Boss debuff related stats")]
   [SerializeField]
   float _debuffDuration;
   [SerializeField]
   float _amountOfDamageDebuffed;
   [SerializeField]
   float _amountOfSpeedDebuffed;
   [SerializeField]
   float _amountOfArmorDebuffed;

   [Header("Boss ultimate related stats")]
   [SerializeField]
   int _bossMaxUltimateUses;
   [SerializeField]
   float _bossUltimateHPThreshold;

   //This section is in charge of exporting every variable in ReadOnly, thanks to the getter.
   //If you want to modify these variables dynamically, you need a setter instead.

   //Boss global combat stats
   public float BossMaxHP { get { return _bossMaxHP; } }
   public float ArmorAmount { get { return _armorAmount; } set { _armorAmount = value; } }
   public float HealthRegenerationAmount { get { return _healthRegenerationAmount; } set { _healthRegenerationAmount = value; } }
   public float CooldownReductionAmount { get { return _cooldownReductionAmount; } set { _cooldownReductionAmount = value; } }
   public float TotalDamage { get { return _totalDamage; } set { _totalDamage = value; } }

   //Boss skill damage stats
   public float MeleeAttackDamage { get { return _meleeAttackDamage; } }
   public float FanAndCrossProjectileDamage { get { return _fanAndCrossProjectileDamage; } }
   public float SweepProjectileDamage { get { return _sweepProjectileDamage; } }
   public float UltimateAttackDamage { get { return _ultimateAttackDamage; } }


   //Boss skill cooldown stats
   public float MeleeCooldown { get { return _meleeCooldown; } }
   public float FanRangedCooldown { get { return _fanRangedCooldown; } }
   public float SweepRangedCooldown { get { return _sweepRangedCooldown; } }
   public float CrossRangedCooldown { get { return _crossRangedCooldown; } }
   public float UltimateCooldown { get { return _ultimateCooldown; } }
   public float BuffCooldown { get { return _buffCooldown; } }
   public float DebuffCooldown { get { return _debuffCooldown; } }
   public float DodgeCooldown { get { return _dodgeCooldown; } }

   // Boss movement speed stats
   public float FanAndCrossProjectileMovementSpeed { get { return _fanAndCrossProjectileMovementSpeed; } }
   public float FanAndCrossProjectileDecelarationSpeed { get { return _fanAndCrossProjectileDecelerationSpeed; } }
   public float SweepProjectileMovementSpeed { get { return _sweepProjectileMovementSpeed; } }
   public float DodgeMovementSpeed { get { return _dodgeMovementSpeed; } }

   //Boss projectiles lifetime stats
   public float FanAndCrossProjectileLifetime { get { return _fanAndCrossProjectileLifetime; } }
   public float SweepProjectileLifetime { get { return _sweepProjectileLifetime; } }
   public float MeleeAttackLifetime { get { return _meleeAttackLifetime; } }

   //Boss buff related stats
   public float BuffDuration { get { return _buffDuration; } }
   public float AmountOfArmorBuffed { get { return _amountOfArmorBuffed; } }
   public float AmountOfRegenerationBuffed { get { return _amountOfRegenerationBuffed; } }
   public float AmountOfDamageBuffed { get { return _amountOfDamageBuffed; } }
   public float AmountOfCooldownBuffed { get { return _amountOfCooldownBuffed; } }
   public float AmountOfAnimationSpeedBuffed { get { return _amountOfAnimationSpeedBuffed; } }

   //Boss debuff related stats
   public float DebuffDuration { get { return _debuffDuration; } }
   public float AmountOfDamageDebuffed { get { return _amountOfDamageDebuffed; } }
   public float AmountOfSpeedDebuffed { get { return _amountOfSpeedDebuffed; } }
   public float AmountOfArmorDebuffed { get { return _amountOfArmorDebuffed; } }

   //Boss ultimate related stats
   public int BossMaxUltimateUses { get { return _bossMaxUltimateUses; } }
   public float BossUltimateHPThreshold { get { return _bossUltimateHPThreshold; } }
}