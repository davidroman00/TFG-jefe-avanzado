using UnityEngine;

public class BossReferences : MonoBehaviour
{
    //Here, there are stored and exported every object required for the boss to operate correctly.
    //The fact that there are some values at 'none' on inspector means they are not necessary for the current phase of the boss. 
    [Header("Player transform")]
    [SerializeField]
    Transform _playerTransform;

    [Header("Projectiles and weapons spawn points")]
    [SerializeField]
    Transform _meleeAttackSpawnPoint;
    [SerializeField]
    Transform[] _fanProjectilesSpawnPoints;
    [SerializeField]
    Transform[] _sweepProjectilesSpawnPoints;
    [SerializeField]
    Transform[] _crossProjectilesSpawnPoints;
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

    [Header("Boss UI images")]
    [SerializeField]
    GameObject _buffIcon;
    [SerializeField]
    GameObject _debuffIcon;

    [Header("Boss particle systems")]
    [SerializeField]
    ParticleSystem _buffParticleSystem;
    [SerializeField]
    ParticleSystem _debuffParticleSystem;

    //General utility variables
    Transform _actualTeleportPosition;
    bool _isActualDodgeActive;
    bool _hasReachedMidDodge;
    int _actualUltimateUses;
    bool _isOutsideArena;


    //Player transform
    public Transform PlayerTransform { get { return _playerTransform; } }

    //Projectiles and weapons spawn points
    public Transform MeleeAttackSpawnPoint { get { return _meleeAttackSpawnPoint; } }
    public Transform[] FanProjectilesSpawnPoints { get { return _fanProjectilesSpawnPoints; } }
    public Transform[] SweepProjectilesSpawnPoints { get { return _sweepProjectilesSpawnPoints; } }
    public Transform[] CrossProjectilesSpawnPoints { get { return _crossProjectilesSpawnPoints; } }
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

    //Boss UI images
    public GameObject BuffIcon { get { return _buffIcon; } }
    public GameObject DebuffIcon { get { return _debuffIcon; } }

    //Boss particles systems
    public ParticleSystem BuffParticleSystem { get { return _buffParticleSystem; } }
    public ParticleSystem DebuffParticleSystem { get { return _debuffParticleSystem; } }

    //General utility variables
    public Transform ActualTeleportPosition { get { return _actualTeleportPosition; } set { _actualTeleportPosition = value; } }
    public bool IsActualDodgeActive { get { return _isActualDodgeActive; } set { _isActualDodgeActive = value; } }
    public bool HasReachedMidDodge { get { return _hasReachedMidDodge; } set { _hasReachedMidDodge = value; } }
    public int ActualUltimateUses { get { return _actualUltimateUses; } set { _actualUltimateUses = value; } }
    public bool IsOutsideArena { get { return _isOutsideArena; } set { _isOutsideArena = value; } }
}
