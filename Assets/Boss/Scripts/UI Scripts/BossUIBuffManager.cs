using UnityEngine;
using UnityEngine.UI;

public class BossUIBuffManager : MonoBehaviour
{
    [SerializeField]
    Image _buffGreyMask;
    [SerializeField]
    BossStats _bossStats;
    [SerializeField]
    BossCooldownManager _bossCooldownManager;
    void Update()
    {
        HandleGreyMask();
    }
    void HandleGreyMask()
    {
        _buffGreyMask.fillAmount = (Time.time - _bossCooldownManager.LastBuff) / _bossStats.BuffDuration;
    }
}
