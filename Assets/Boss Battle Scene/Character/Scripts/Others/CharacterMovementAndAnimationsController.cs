using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovementAndAnimationsController : MonoBehaviour
{
    //This is the core script of the character.
    CharacterStats _characterStats;
    CharacterReferences _characterReferences;
    CharacterCooldownManager _characterCooldownManager;
    CharacterController _characterController;
    Animator _animator;

    //Necessary variables to handle movement, rotation and animations.
    float _turnSmoothTime = .075f;
    float _turnSmoothVelocity;
    float _targetAngle;
    float _appliedAngle;
    Vector3 _initialDirection;
    Vector3 _moveDirection;

    //Input actions
    InputAction _move;
    InputAction _interact;
    InputAction _heal;
    InputAction _dodge;
    InputAction _fire1;
    InputAction _fire2;
    InputAction _weapon1;
    InputAction _weapon2;
    InputAction _weaponSwap;
    InputAction _pause;

    int _meleeAttacksCounter;

    void Awake()
    {
        _characterStats = GetComponent<CharacterStats>();
        _characterReferences = GetComponent<CharacterReferences>();
        _characterCooldownManager = GetComponent<CharacterCooldownManager>();
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        _characterReferences.CharacterControlls = new CharacterControlls();
    }
    void OnEnable()
    {
        _move = _characterReferences.CharacterControlls.Player.Move;
        _interact = _characterReferences.CharacterControlls.Player.Interact;
        _heal = _characterReferences.CharacterControlls.Player.Heal;
        _dodge = _characterReferences.CharacterControlls.Player.Dodge;
        _fire1 = _characterReferences.CharacterControlls.Player.Fire1;
        _fire2 = _characterReferences.CharacterControlls.Player.Fire2;
        _weapon1 = _characterReferences.CharacterControlls.Player.Weapon1;
        _weapon2 = _characterReferences.CharacterControlls.Player.Weapon2;
        _weaponSwap = _characterReferences.CharacterControlls.Player.WeaponSwap;
        _pause = _characterReferences.CharacterControlls.Player.Pause;

        _move.Enable();
        _heal.Enable();
        _interact.Enable();
        _dodge.Enable();
        _fire1.Enable();
        _fire2.Enable();
        _weapon1.Enable();
        _weapon2.Enable();
        _weaponSwap.Enable();
        _pause.Enable();

        _interact.performed += Interact;
        _heal.performed += Heal;
        _dodge.performed += Dodge;
        _fire1.performed += Fire1;
        _fire2.performed += Fire2;
        _fire2.canceled += Fire2Relese;
        _weapon1.performed += Weapon1;
        _weapon2.performed += Weapon2;
        _pause.performed += Pause;
    }
    void OnDisable()
    {
        _move.Disable();
        _heal.Disable();
        _interact.Disable();
        _dodge.Disable();
        _fire1.Disable();
        _fire2.Disable();
        _weapon1.Disable();
        _weapon2.Disable();
        _weaponSwap.Disable();
        _pause.Disable();
    }
    void Update()
    {
        CharacterMoveChecker();
        WeaponSwapChecker();
    }

    void CharacterMoveChecker()
    {
        if (!_animator.GetBool("isFire2"))
        {
            if (_move.ReadValue<Vector2>().magnitude > .05f && !_characterReferences.IsAttacking && !_characterReferences.IsDodging && !_characterReferences.IsHealing && !_characterReferences.IsStaggered && !_characterReferences.IsSwapping)
            {
                HandleCharacterMovementAndRotation();
                _animator.SetBool("isWalking", true);
            }
            else
            {
                _animator.SetBool("isWalking", false);
            }
        }
    }
    void Interact(InputAction.CallbackContext context)
    {

    }
    void Heal(InputAction.CallbackContext context)
    {
        if (!_characterCooldownManager.IsHealOnCooldown() && _characterStats.HealCharges > 0)
        {
            _animator.SetTrigger("heal");
        }
    }
    void Dodge(InputAction.CallbackContext context)
    {
        if (_characterStats.CurrentStamina > _characterStats.DodgeStaminaConsumption)
        {
            _characterReferences.DodgeMoveDirection = MoveDirection();

            _animator.SetTrigger("dodge");
        }
    }
    void Fire1(InputAction.CallbackContext context)
    {
        _animator.SetTrigger("fire1");
        StopAllCoroutines();
        if (_animator.GetInteger("currentWeapon") == 0 && !_characterReferences.IsAttacking && !_characterReferences.IsAttackStoredAndNotPerformed)
        {
            if (_meleeAttacksCounter < _characterStats.MeleeAttacksDamage.Length)
            {
                _meleeAttacksCounter++;
                _animator.SetInteger("meleeAttacksCount", _meleeAttacksCounter);
            }
            else
            {
                _meleeAttacksCounter = 0;
                _meleeAttacksCounter++;
                _animator.SetInteger("meleeAttacksCount", _meleeAttacksCounter);
            }
            StartCoroutine(DelayMeleeAttackReset());
            _characterReferences.IsAttackStoredAndNotPerformed = true;
        }
    }
    IEnumerator DelayMeleeAttackReset()
    {
        yield return new WaitForSeconds(3.5f);
        _meleeAttacksCounter = 0;
    }
    void Fire2(InputAction.CallbackContext context)
    {
        _animator.SetBool("isFire2", true);
        if (_animator.GetInteger("currentWeapon") == 0)
        {
            GetComponentInChildren<ShieldAnimationsManager>().SwitchToParryStance();
            StartCoroutine(DelayParryStart());
        }
    }
    void Fire2Relese(InputAction.CallbackContext context)
    {
        _animator.SetBool("isFire2", false);
        if (_animator.GetInteger("currentWeapon") == 0)
        {
            GetComponentInChildren<ShieldAnimationsManager>().SwitchToIdleStance();
            StopAllCoroutines();
            _characterStats.DamageBlocked = 0;
        }
    }
    IEnumerator DelayParryStart()
    {
        yield return new WaitForSeconds(.2f);
        _characterStats.DamageBlocked = 100;
        yield return new WaitForSeconds(_characterStats.ParryBlockingTime);
        _characterStats.DamageBlocked = _characterStats.ParryDamageReduction;
    }
    void Weapon1(InputAction.CallbackContext context)
    {
        _animator.SetInteger("currentWeapon", 0);
        _animator.SetTrigger("swap");
    }
    void Weapon2(InputAction.CallbackContext context)
    {
        _animator.SetInteger("currentWeapon", 1);
        _animator.SetTrigger("swap");
    }
    void WeaponSwapChecker()
    {
        if (_weaponSwap.ReadValue<Vector2>().normalized.y > 0 || _weaponSwap.ReadValue<Vector2>().normalized.y < 0)
        {
            if (_animator.GetInteger("currentWeapon") == 0)
            {
                _animator.SetInteger("currentWeapon", 1);
            }
            else
            {
                _animator.SetInteger("currentWeapon", 0);
            }
            _animator.SetTrigger("swap");
        }
    }
    void Pause(InputAction.CallbackContext context)
    {

    }

    void HandleCharacterMovementAndRotation()
    {
        _characterController.Move(_characterStats.BaseMovementSpeed * Time.deltaTime * (1 + _characterStats.TotalMovementSpeedBonus / 100) * MoveDirection());
    }
    Vector3 MoveDirection(){
        Vector2 inputVector = _move.ReadValue<Vector2>();
        _initialDirection = new(inputVector.x, 0f, inputVector.y);

        _targetAngle = Mathf.Atan2(_initialDirection.x, _initialDirection.z) * Mathf.Rad2Deg + _characterReferences.Camera.eulerAngles.y;
        _appliedAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
        transform.rotation = Quaternion.Euler(0, _appliedAngle, 0);

        _moveDirection = Quaternion.Euler(0, _targetAngle, 0) * Vector3.forward;
        
        return _moveDirection;
    }
}
