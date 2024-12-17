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
    float _horizontalInput;
    float _verticalInput;
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
        if (_move.ReadValue<Vector2>().magnitude > .05f && !_characterReferences.IsAttacking && !_characterReferences.IsDashing)
        {
            HandleCharacterMovementAndRotation();
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
    }
    void Interact(InputAction.CallbackContext context)
    {

    }
    void Heal(InputAction.CallbackContext context)
    {

    }
    void Dodge(InputAction.CallbackContext context)
    {

    }
    void Fire1(InputAction.CallbackContext context)
    {

    }
    void Fire2(InputAction.CallbackContext context)
    {

    }
    void Weapon1(InputAction.CallbackContext context)
    {

    }
    void Weapon2(InputAction.CallbackContext context)
    {

    }
    void Pause(InputAction.CallbackContext context)
    {

    }
    void WeaponSwapChecker()
    {

    }
    void HandleCharacterMovementAndRotation()
    {
        Vector2 inputVector = _move.ReadValue<Vector2>();
        _initialDirection = new(inputVector.x, 0f, inputVector.y);

        _targetAngle = Mathf.Atan2(_initialDirection.x, _initialDirection.z) * Mathf.Rad2Deg + _characterReferences.Camera.eulerAngles.y;
        _appliedAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
        transform.rotation = Quaternion.Euler(0, _appliedAngle, 0);

        _moveDirection = Quaternion.Euler(0, _targetAngle, 0) * Vector3.forward;
        _characterController.Move(_characterStats.BaseMovementSpeed * Time.deltaTime * _moveDirection);

        _characterReferences.DashMoveDirection = _moveDirection;
    }
}
