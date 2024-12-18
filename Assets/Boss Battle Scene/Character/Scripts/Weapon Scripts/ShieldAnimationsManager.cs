
using UnityEngine;

public class ShieldAnimationsManager : MonoBehaviour
{
    Animation _animation;
    void Awake()
    {
        _animation = GetComponent<Animation>();
    }
    public void SwitchToParryStance()
    {
        _animation.Play("shield_switch_to_parry");
    }
    public void SwitchToIdleStance()
    {
        _animation.Play("shield_switch_to_idle");

    }
}
