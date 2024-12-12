
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

    [Header("Character audio references")]
    [SerializeField]
    AudioSource _battleThemeSource;
    // [SerializeField]
    // AudioClip _deathTheme;

    //Other private references
    Vector3 _dashMoveDirection;
    bool _isActualDashActive;
    bool _isAttacking;
    bool _isdashing;
    bool _isSweepBreak;

    //Character camera
    public Transform Camera { get { return _camera; } }

    //Character UI related stuff
    public GameObject DeathTextUI { get { return _deathTextUI; } }
    public CharacterUIHealthManager CharacterUIHealthManager { get { return _characterHealthUI; } }

    //Character audio references
    public AudioSource BattleThemeSource { get { return _battleThemeSource; } }
    //public AudioClip DeathTheme { get { return _deathTheme; } }

    //Other private references
    public Vector3 DashMoveDirection { get { return _dashMoveDirection; } set { _dashMoveDirection = value; } }
    public bool IsActualDashActive { get { return _isActualDashActive; } set { _isActualDashActive = value; } }
    public bool IsAttacking { get { return _isAttacking; } set { _isAttacking = value; } }
    public bool IsDashing { get { return _isdashing; } set { _isdashing = value; } }
    public bool IsSweepBreak { get { return _isSweepBreak; } set { _isSweepBreak = value; } }
}
