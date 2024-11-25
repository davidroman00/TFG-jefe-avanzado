using UnityEngine;
using UnityEngine.UI;

public class BossUIDebuffManager : MonoBehaviour
{
    [SerializeField]
    Image _debuffGreyMask;
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
        _debuffGreyMask.fillAmount = (Time.time - _bossCooldownManager.LastDebuff) / _bossStats.DebuffDuration;
    }
}
