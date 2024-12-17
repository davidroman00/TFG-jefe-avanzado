using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //Here, there are stored every variable relative to the character statistics.
    [Header("Character global character stats")]
    [SerializeField]
    float _maxHealth;
    [SerializeField]
    float _currentHealth;
    [SerializeField]
    float _maxStamina;
    [SerializeField]
    float _currentStamina;
    [SerializeField]
    float _staminaRegeneration;
    [SerializeField]
    float _armorAmount;
    [SerializeField]
    float _damageBlocked;
    [SerializeField]
    float _totalDamageBonus;
    [SerializeField]
    float _baseMovementSpeed;
    [SerializeField]
    float _totalMovementSpeedBonus;

    [Header("Character attacks related stats")]
    [SerializeField]
    float[] _meleeAttacksDamage;
    [SerializeField]
    float _bowBaseDamage;
    [SerializeField]
    float _bowMaxChargeDamageMultiplier;

    [Header("Character dash related stats")]
    [SerializeField]
    float _dodgeMovementSpeed;
    [SerializeField]
    float _dodgeAccelerationSpeed;
    [SerializeField]
    float _dodgeStaminaConsumption;

    [Header("Character defensive moves stats")]
    [SerializeField]
    float _parryDamageReduction;
    [SerializeField]
    float _parryBlockingTime;
    [SerializeField]
    float _healAmount;
    [SerializeField]
    float _healCharges;
    [SerializeField]
    float _healCooldown;

    [Header("Character stagger related stats")]
    [SerializeField]
    float _staggerProcDamageThreshold;
    [SerializeField]
    float _staggerCooldown;

    //This section is in charge of exporting every variable in ReadOnly, thanks to the getter.
    //If you want to modify these variables dynamically, you need a setter instead.

    //Global character stats
    public float MaxHealth { get { return _maxHealth; } }
    public float CurrentHealth { get { return _currentHealth; } set { _currentHealth = value; } }
    public float MaxStamina { get { return _maxStamina; } }
    public float CurrentStamina { get { return _currentStamina; } set { _currentStamina = value; } }
    public float StaminaRegeneration { get { return _staminaRegeneration; } }
    public float ArmorAmount { get { return _armorAmount; } set { _armorAmount = value; } }
    public float DamageBlocked { get { return _damageBlocked; } set { _damageBlocked = value; } }
    public float TotalDamageBonus { get { return _totalDamageBonus; } set { _totalDamageBonus = value; } }
    public float BaseMovementSpeed { get { return _baseMovementSpeed; } set { _baseMovementSpeed = value; } }
    public float TotalMovementSpeedBonus { get { return _totalMovementSpeedBonus; } set { _totalMovementSpeedBonus = value; } }


    //Character attacks related stats
    public float[] MeleeAttacksDamage { get { return _meleeAttacksDamage; } }
    public float BowBaseDamage { get { return _bowBaseDamage; } }
    public float BowMaxChargeDamageMultiplier { get { return _bowMaxChargeDamageMultiplier; } }

    //Character dash related stats
    public float DodgeMovementSpeed { get { return _dodgeMovementSpeed; } }
    public float DodgeAccelerationSpeed { get { return _dodgeAccelerationSpeed; } }
    public float DodgeStaminaConsumption { get { return _dodgeStaminaConsumption; } }

    //Character defensive moves stats
    public float ParryDamageReduction { get { return _parryDamageReduction; } }
    public float ParryBlockingTime { get { return _parryBlockingTime; } }
    public float HealAmount { get { return _healAmount; } }
    public float HealCharges { get { return _healCharges; } set { _healCharges = value; } }
    public float HealCooldown { get { return _healCooldown; } }

    //Character stagger related stats
    public float StaggerProcDamageThreshold { get { return _staggerProcDamageThreshold; } }
    public float StaggerCooldown { get { return _staggerCooldown; } }

}