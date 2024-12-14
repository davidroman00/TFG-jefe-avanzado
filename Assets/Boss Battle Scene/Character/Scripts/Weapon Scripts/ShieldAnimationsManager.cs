
using UnityEngine;

public class ShieldAnimationsManager : MonoBehaviour
{
    Animation _animationReference;
    void Awake()
    {
        _animationReference = GetComponent<Animation>();
    }
    public void SwitchToParryStance()
    {
        _animationReference.Play("shield_switch_to_parry");
    }
    public void SwitchToIdleStance()
    {
        _animationReference.Play("shield_switch_to_idle");

    }
}
