
using UnityEngine;
using UnityEngine.UI;

public class CharacterReferences : MonoBehaviour
{
    [Header("Character camera")]
    [SerializeField]
    Transform _camera;

    [Header("Character UI related stuff")]
    [SerializeField]
    GameObject _deathTextUI;
    [SerializeField]
    CharacterUIHealthManager _characterHealthUI;
    [SerializeField]
    CharacterUIStaminaManager _characterStaminaUI;

    [Header("Character audio references")]
    [SerializeField]
    AudioSource _battleThemeSource;
    // [SerializeField]
    // AudioClip _deathTheme;

    [Header("Character model references")]
    [SerializeField]
    GameObject _characterSword;
    [SerializeField]
    GameObject _characterShield;
    [SerializeField]
    GameObject _characterBow;
    [SerializeField]
    GameObject _characterArrow;

    //Other private references
    CharacterControlls _characterControlls;
    Vector3 _dodgeMoveDirection;
    bool _isActualDodgeActive;
    bool _hasReachedMidDodge;
    bool _isAttacking;
    bool _isDodging;
    bool _isHealing;
    bool _isStaggered;
    bool _isSwapping;
    bool _isSweepBreak;

    //Character camera
    public Transform Camera { get { return _camera; } }

    //Character UI related stuff
    public GameObject DeathTextUI { get { return _deathTextUI; } }
    public CharacterUIHealthManager CharacterUIHealthManager { get { return _characterHealthUI; } }
    public CharacterUIStaminaManager CharacterUIStamina { get { return _characterStaminaUI; } }

    //Character audio references
    public AudioSource BattleThemeSource { get { return _battleThemeSource; } }
    //public AudioClip DeathTheme { get { return _deathTheme; } }

    //Character model references
    public GameObject CharacterSword { get { return _characterSword; } }
    public GameObject CharacterShield { get { return _characterShield; } }
    public GameObject CharacterBow { get { return _characterBow; } }
    public GameObject CharacteArrow { get { return _characterArrow; } }

    //Other private references
    public CharacterControlls CharacterControlls { get { return _characterControlls; } set { _characterControlls = value; } }
    public Vector3 DodgeMoveDirection { get { return _dodgeMoveDirection; } set { _dodgeMoveDirection = value; } }
    public bool IsActualDodgeActive { get { return _isActualDodgeActive; } set { _isActualDodgeActive = value; } }
    public bool HasReachedMidDodge { get { return _hasReachedMidDodge; } set { _hasReachedMidDodge = value; } }
    public bool IsAttacking { get { return _isAttacking; } set { _isAttacking = value; } }
    public bool IsDodging { get { return _isDodging; } set { _isDodging = value; } }
    public bool IsHealing { get { return _isHealing; } set { _isHealing = value; } }
    public bool IsStaggered { get { return _isStaggered; } set { _isStaggered = value; } }
    public bool IsSwapping { get { return _isSwapping; } set { _isSwapping = value; } }
    public bool IsSweepBreak { get { return _isSweepBreak; } set { _isSweepBreak = value; } }
}
