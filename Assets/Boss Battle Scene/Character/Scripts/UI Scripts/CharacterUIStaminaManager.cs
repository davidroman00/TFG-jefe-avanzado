
using UnityEngine;
using UnityEngine.UI;

public class CharacterUIStaminaManager : MonoBehaviour
{
    //This script is exactly the same as 'BossUIHealthManager'.
    //However, it is better to keep them as different scripts in case you wanted to alter the character UI differently as the boss one.
    Slider _staminaSlider;
    void Awake()
    {
        _staminaSlider = GetComponent<Slider>();
    }
    public void SetMaxStamina(float maxStamina)
    {
        _staminaSlider.maxValue = maxStamina;
    }
    public void SetCurrentStamina(float currentStamina)
    {
        _staminaSlider.value = currentStamina;
    }
}
