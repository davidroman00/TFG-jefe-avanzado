using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //Here, there are stored every variable relative to the character statistics.
    [SerializeField]
    float _maxHealth;
    [SerializeField]
    float _armorAmount;
    [SerializeField]
    float _totalMovementSpeed;
    [SerializeField]
    float _totalDamage;
    [SerializeField]
    float _movementSpeed;
    [SerializeField]
    float _backdashMovementSpeed;
    [SerializeField]
    float _attackDamage;
    [SerializeField]
    float _attackCooldown;
    [SerializeField]
    float _backdashCooldown;
    bool _isSweepBreak;

    //This section is in charge of exporting every variable in ReadOnly, thanks to the getter.
    //If you want to modify these variables dynamically, you need a setter instead.
    public float MaxHealth { get { return _maxHealth; } }
    public float ArmorAmount { get { return _armorAmount; } set { _armorAmount = value; } }
    public float TotalDamage { get { return _totalDamage; } set { _totalDamage = value; } }
    public float TotalMovementSpeed { get { return _totalMovementSpeed; } set { _totalMovementSpeed = value; } }
    public float MovementSpeed { get { return _movementSpeed; } set { _movementSpeed = value; } }
    public float BackdashMovementSpeed { get { return _backdashMovementSpeed; } }
    public float AttackDamage { get { return _attackDamage; } }
    public float AttackCooldown { get { return _attackCooldown; } }
    public float BackdashCooldown { get { return _backdashCooldown; } }
    public bool IsSweepBreak { get { return _isSweepBreak; } set { _isSweepBreak = value; } }
}