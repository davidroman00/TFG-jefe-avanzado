using UnityEngine;

public class BossReferences : MonoBehaviour
{
    //Here, there are stored and exported every object required for the boss to operate correctly.
    //The fact that there are some values at 'none' on inspector means they are not necessary for the current phase of the boss.    
    [SerializeField]
    Transform[] _fanRangedSpawnPoints;
    [SerializeField]
    Transform[] _fanBossPositions;
    [SerializeField]
    Transform[] _sweepRangedSpawnPoints;
    [SerializeField]
    Transform _sweepBossPosition;
    [SerializeField]
    Transform[] _crossRangedSpawnPoints;
    [SerializeField]
    Transform _crossBossPosition;
    [SerializeField]
    Transform _meleeAttackSpawnPoint;
    [SerializeField]
    Transform _meleeAttackTeleportPoint;
    [SerializeField]
    GameObject _sweepRangedProjectile;
    [SerializeField]
    GameObject _fanAndCrossRangedProjectile;
    [SerializeField]
    GameObject _meleeAttackDevice;
    [SerializeField]
    Transform _ultimateBossPosition;
    [SerializeField]
    Transform _ultimateWeaponSpawnPoint;
    [SerializeField]
    Transform _ultimateDeviceSpawnPoint;
    [SerializeField]
    GameObject _ultimateWeaponPrefab;
    [SerializeField]
    GameObject _ultimateDevicePrefab;
    [SerializeField]
    Transform _playerTransform;
    Transform _actualTeleportPosition;
    bool _isActualRightDodgeActive;
    bool _isActualLeftDodgeActive;

    public Transform[] FanRangedSpawnPoints { get { return _fanRangedSpawnPoints; } }
    public Transform[] FanBossPositions { get { return _fanBossPositions; } }
    public Transform[] SweepRangedSpawnPoints { get { return _sweepRangedSpawnPoints; } }
    public Transform SweepBossPosition { get { return _sweepBossPosition; } }
    public Transform[] CrossRangedSpawnPoints { get { return _crossRangedSpawnPoints; } }
    public Transform CrossBossPosition { get { return _crossBossPosition; } }
    public Transform MeleeAttackSpawnPoint { get { return _meleeAttackSpawnPoint; } }
    public GameObject SweepRangedProjectile { get { return _sweepRangedProjectile; } }
    public GameObject FanAndCrossRangedProjectile { get { return _fanAndCrossRangedProjectile; } }
    public GameObject MeleeAttackDevice { get { return _meleeAttackDevice; } }
    public Transform MeleeAttackTeleportPoint { get { return _meleeAttackTeleportPoint; } }
    public Transform UltimateBossPosition { get { return _ultimateBossPosition; } }
    public Transform UltimateWeaponSpawnPoint { get { return _ultimateWeaponSpawnPoint; } }
    public Transform UltimateDeviceSpawnPoint { get { return _ultimateDeviceSpawnPoint; } }
    public GameObject UltimateWeaponPrefab { get { return _ultimateWeaponPrefab; } }
    public GameObject UltimateDevicePrefab { get { return _ultimateDevicePrefab; } }
    public Transform PlayerTransform { get { return _playerTransform; } }
    public Transform ActualTeleportPosition { get { return _actualTeleportPosition; } set { _actualTeleportPosition = value; } }
    public bool IsActualRightDodgeActive { get { return _isActualRightDodgeActive; } set { _isActualRightDodgeActive = value; } }
    public bool IsActualLeftDodgeActive { get { return _isActualLeftDodgeActive; } set { _isActualLeftDodgeActive = value; } }
}
