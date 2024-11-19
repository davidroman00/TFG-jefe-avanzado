using UnityEngine;

public class BossReferences : MonoBehaviour
{
    //Here, there are stored and exported every object required for the boss to operate correctly.
    //The fact that there are some values at 'none' on inspector means they are not necessary for the current phase of the boss.   
    [Header("Projectiles and weapons spawn points")]
    [SerializeField]
    Transform _meleeAttackSpawnPoint;
    [SerializeField]
    Transform[] _fanRangedSpawnPoints;
    [SerializeField]
    Transform[] _sweepRangedSpawnPoints;
    [SerializeField]
    Transform[] _crossRangedSpawnPoints;
    [SerializeField]
    Transform _ultimateWeaponSpawnPoint;
    [SerializeField]
    Transform _ultimateDeviceSpawnPoint;

    [Header("Projectiles and weapons prefabs")]
    [SerializeField]
    GameObject _meleeAttackPrefab;
    [SerializeField]
    GameObject _fanAndCrossProjectilePrefab;
    [SerializeField]
    GameObject _sweepProjectilePrefab;
    [SerializeField]
    GameObject _ultimateWeaponPrefab;
    [SerializeField]
    GameObject _ultimateDevicePrefab;

    [Header("Boss teleport positions")]
    [SerializeField]
    Transform _meleeAttackBossPosition;
    [SerializeField]
    Transform[] _fanBossPositions;
    [SerializeField]
    Transform _sweepBossPosition;
    [SerializeField]
    Transform _crossBossPosition;
    [SerializeField]
    Transform _ultimateBossPosition;

    //General utility variables
    [SerializeField]
    Transform _playerTransform;
    Transform _actualTeleportPosition;
    bool _isActualRightDodgeActive;
    bool _isActualLeftDodgeActive;
    int _actualUltimateUses;
    bool _isOutsideArena;

    //Projectiles and weapons spawn points
    public Transform MeleeAttackSpawnPoint { get { return _meleeAttackSpawnPoint; } }
    public Transform[] FanRangedSpawnPoints { get { return _fanRangedSpawnPoints; } }
    public Transform[] SweepRangedSpawnPoints { get { return _sweepRangedSpawnPoints; } }
    public Transform[] CrossRangedSpawnPoints { get { return _crossRangedSpawnPoints; } }
    public Transform UltimateWeaponSpawnPoint { get { return _ultimateWeaponSpawnPoint; } }
    public Transform UltimateDeviceSpawnPoint { get { return _ultimateDeviceSpawnPoint; } }

    //Projectiles and weapons prefabs
    public GameObject MeleeAttackPrefab { get { return _meleeAttackPrefab; } }
    public GameObject FanAndCrossProjectilePrefab { get { return _fanAndCrossProjectilePrefab; } }
    public GameObject SweepProjectilePrefab { get { return _sweepProjectilePrefab; } }
    public GameObject UltimateWeaponPrefab { get { return _ultimateWeaponPrefab; } }
    public GameObject UltimateDevicePrefab { get { return _ultimateDevicePrefab; } }

    //Boss teleport positions
    public Transform MeleeAttackBossPosition { get { return _meleeAttackBossPosition; } }
    public Transform[] FanBossPositions { get { return _fanBossPositions; } }
    public Transform SweepBossPosition { get { return _sweepBossPosition; } }
    public Transform CrossBossPosition { get { return _crossBossPosition; } }
    public Transform UltimateBossPosition { get { return _ultimateBossPosition; } }

    //General utility variables
    public Transform PlayerTransform { get { return _playerTransform; } }
    public Transform ActualTeleportPosition { get { return _actualTeleportPosition; } set { _actualTeleportPosition = value; } }
    public bool IsActualRightDodgeActive { get { return _isActualRightDodgeActive; } set { _isActualRightDodgeActive = value; } }
    public bool IsActualLeftDodgeActive { get { return _isActualLeftDodgeActive; } set { _isActualLeftDodgeActive = value; } }
    public int ActualUltimateUses { get { return _actualUltimateUses; } set { _actualUltimateUses = value; } }
    public bool IsOutsideArena { get { return _isOutsideArena; } set { _isOutsideArena = value; } }
}
