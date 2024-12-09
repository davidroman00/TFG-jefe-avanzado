using UnityEngine;
using UnityEngine.UI;

public class CharacterMovementAndAnimationsController : MonoBehaviour
{
    //This is the core script of the character.

    //Necessary variables to handle Cooldowns.
    float _lastBackdashUse;
    CharacterStats _characterStats;
    CharacterReferences _characterReferences;

    //Necessary variables to handle movement, rotation and animations.
    float _turnSmoothTime = .075f;
    float _turnSmoothVelocity;
    float _targetAngle;
    float _appliedAngle;
    float _horizontalInput;
    float _verticalInput;
    Vector3 _initialDirection;
    Vector3 _moveDirection;
    
    CharacterController _characterController;
    [SerializeField]
    Transform _camera;
    Animator _animator;

    void Awake()
    {
        _characterStats = GetComponent<CharacterStats>();
        _characterReferences = GetComponent<CharacterReferences>();
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleInput();
        ShowSkillsCooldownOnScreen();
    }

    void HandleInput()
    {
        //Storing movement input.
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        _initialDirection = new Vector3(_horizontalInput, 0f, _verticalInput).normalized;

        //Handling animations, cooldowns and other inputs.
        if (_initialDirection.magnitude > .05f && !_characterReferences.IsAttacking && !_characterReferences.IsDashing)
        {
            HandlePlayerMovementAndRotation();
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !IsBackdashOnCooldown())
        {
            _animator.SetTrigger("backdash");
            _lastBackdashUse = Time.time;
        }
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("attack");
        }
    }
    void HandlePlayerMovementAndRotation()
    {
        //Handling character rotation.
        _targetAngle = Mathf.Atan2(_initialDirection.x, _initialDirection.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
        _appliedAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
        transform.rotation = Quaternion.Euler(0, _appliedAngle, 0);

        //Handling character movement.
        _moveDirection = Quaternion.Euler(0, _targetAngle, 0) * Vector3.forward;
        _characterController.Move(_characterStats.BaseMovementSpeed * (1 + _characterStats.TotalMovementSpeedIncrease / 100) * Time.deltaTime * _moveDirection.normalized);

        _characterReferences.DashMoveDirection = Quaternion.Euler(0, _appliedAngle, 0) * Vector3.back;
    }
    //Handling cooldowns on screen.
    void ShowSkillsCooldownOnScreen()
    {
        if (IsBackdashOnCooldown())
        {
            _characterReferences.DashImage.fillAmount = (Time.time - _lastBackdashUse) / _characterStats.DashCooldown;
        }
        else if (!IsBackdashOnCooldown())
        {
            _characterReferences.DashImage.fillAmount = 0;
        }
    }
    //Handling cooldowns.
    bool IsBackdashOnCooldown()
    {
        return Time.time < _lastBackdashUse + _characterStats.DashCooldown;
    }
}
