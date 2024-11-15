using UnityEngine;

public class BossReferences : MonoBehaviour
{
    //Here, there are stored and exported every object required for the boss to operate correctly.
    //The fact that there are some values at 'none' on inspector means they are not necessary for the current phase of the boss.    
    [SerializeField]
    Transform[] _fanRangedSpawnPoint;
    [SerializeField]
    Transform[] _fanBossPositions;
    [SerializeField]
    Transform[] _sweepRangedSpawnPoint;
    [SerializeField]
    Transform _sweepBossPosition;
    [SerializeField]
    Transform[] _crossRangedSpawnPoint;
    [SerializeField]
    Transform _crossBossPosition;
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

    public Transform[] FanRangedSpawnPoint { get { return _fanRangedSpawnPoint; } }
    public Transform[] FanBossPositions { get { return _fanBossPositions; } }
    public Transform[] SweepRangedSpawnPoint { get { return _sweepRangedSpawnPoint; } }
    public Transform SweepBossPosition { get { return _sweepBossPosition; } }
    public Transform[] CrossRangedSpawnPoint { get { return _crossRangedSpawnPoint; } }
    public Transform CrossBossPosition { get { return _crossBossPosition; } }
    public Transform UltimateBossPosition { get { return _ultimateBossPosition; } }
    public Transform UltimateWeaponSpawnPoint { get { return _ultimateWeaponSpawnPoint; } }
    public Transform UltimateDeviceSpawnPoint { get { return _ultimateDeviceSpawnPoint; } }
    public GameObject UltimateWeaponPrefab { get { return _ultimateWeaponPrefab; } }
    public GameObject UltimateDevicePrefab { get { return _ultimateDevicePrefab; } }
    public Transform PlayerTransform { get { return _playerTransform; } }
}
