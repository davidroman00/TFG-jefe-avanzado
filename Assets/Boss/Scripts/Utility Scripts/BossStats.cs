using UnityEngine;

public class BossStats : MonoBehaviour
{
   //Here, there are stored every variable relative to the boss statistics.
   //The fact that there are some values at 0 on inspector means they are not necessary for the current phase of the boss.
   [SerializeField]
   float _armor;
   [SerializeField]
   float _healthRegeneration;
   [SerializeField]
   float _cooldownReduction;
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
   public float Armor { get { return _armor; } set { _armor = value; } }
   public float HealthRegeneration { get { return _healthRegeneration; } set { _healthRegeneration = value; } }
   public float CooldownReduction { get { return _cooldownReduction; } set { _cooldownReduction = value; } }
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