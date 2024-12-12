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
    float _armorAmount;
    [SerializeField]
    float _totalDamage;
    [SerializeField]
    float _baseMovementSpeed;
    [SerializeField]
    float _totalMovementSpeedIncrease;

    [Header("Character attacks related stats")]
    [SerializeField]
    float[] _meleeAttacksDamage;
    [SerializeField]
    float _bowBaseDamage;
    [SerializeField]
    float _bowMaxChargeDamageMultiplier;

    [Header("Character dash related stats")]
    [SerializeField]
    float _dashMovementSpeed;
    [SerializeField]
    float _dashAccelerationSpeed;

    [Header("Character defensive moves stats")]
    [SerializeField]
    float _parryDamageReduction;
    [SerializeField]
    float _parryBlockingTime;
    [SerializeField]
    float _healAmount;
    [SerializeField]
    float _maxHealCharges;
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
    public float ArmorAmount { get { return _armorAmount; } set { _armorAmount = value; } }
    public float TotalDamage { get { return _totalDamage; } set { _totalDamage = value; } }
    public float BaseMovementSpeed { get { return _baseMovementSpeed; } set { _baseMovementSpeed = value; } }
    public float TotalMovementSpeedIncrease { get { return _totalMovementSpeedIncrease; } set { _totalMovementSpeedIncrease = value; } }


    //Character attacks related stats
    public float[] MeleeAttacksDamage { get { return _meleeAttacksDamage; } }
    public float BowBaseDamage { get { return _bowBaseDamage; } }
    public float BowMaxChargeDamageMultiplier { get { return _bowMaxChargeDamageMultiplier; } }

    //Character dash related stats
    public float DashMovementSpeed { get { return _dashMovementSpeed; } }
    public float DashAccelerationSpeed { get { return _dashAccelerationSpeed; } }

    //Character defensive moves stats
    public float ParryDamageReduction { get { return _parryDamageReduction; } }
    public float ParryBlockingTime { get { return _parryBlockingTime; } }
    public float HealAmount { get { return _healAmount; } }
    public float MaxHealCharges { get { return _maxHealCharges; } }
    public float HealCooldown { get { return _healCooldown; } }

    //Character stagger related stats
    public float StaggerProcDamageThreshold { get { return _staggerProcDamageThreshold; } }
    public float StaggerCooldown { get { return _staggerCooldown; } }

}