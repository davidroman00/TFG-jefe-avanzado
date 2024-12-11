
using UnityEngine;
using UnityEngine.UI;

public class CharacterReferences : MonoBehaviour
{
    [Header("Character UI related stuff")]
    [SerializeField]
    Image _dashImage;
    [SerializeField]
    GameObject _deathTextUI;
    [SerializeField]
    Transform _camera;
    [SerializeField]
    CharacterUIHealthManager _characterHealthUI;
    
    [SerializeField]
    AudioSource _battleThemeSource;

    Vector3 _dashMoveDirection;
    bool _isActualDashActive;
    bool _isAttacking;
    bool _isdashing;


    //Character UI related stuff
    public Image DashImage { get { return _dashImage; } }
    public GameObject DeathTextUI { get { return _deathTextUI; } }
    public Transform Camera { get { return _camera; } }
    public CharacterUIHealthManager CharacterUIHealthManager { get { return _characterHealthUI; } }
    public AudioSource BattleThemeSource { get { return _battleThemeSource; } }
    public Vector3 DashMoveDirection { get { return _dashMoveDirection; } set { _dashMoveDirection = value; } }
    public bool IsActualDashActive { get { return _isActualDashActive; } set { _isActualDashActive = value; } }
    public bool IsAttacking { get { return _isAttacking; } set { _isAttacking = value; } }
    public bool IsDashing { get { return _isdashing; } set { _isdashing = value; } }
}
