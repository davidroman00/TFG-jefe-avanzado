
using UnityEngine;

public class CharacterStaminaManager : MonoBehaviour
{
    CharacterStats _characterStats;
    CharacterReferences _characterReferences;

    void Start()
    //Usually, you want to initialize scripts in the Awake() method.
    //However, due to Unity's execution order, you need to use the Start() method here, so it doesn't crash.
    {
        _characterStats = GetComponent<CharacterStats>();
        _characterReferences = GetComponent<CharacterReferences>();
        _characterReferences.CharacterUIStamina.SetMaxStamina(_characterStats.MaxStamina);
        _characterReferences.CharacterUIStamina.SetCurrentStamina(_characterStats.CurrentStamina);
    }
    void Update()
    {
        HandleStaminaRegeneration();
    }
    void HandleStaminaRegeneration()
    {
        _characterStats.CurrentStamina += _characterStats.StaminaRegeneration * Time.deltaTime;
        _characterReferences.CharacterUIStamina.SetCurrentStamina(_characterStats.CurrentStamina);
    }
    public void ReduceStamina(float value)
    //This is a public method since it needs to be accessed from other objects
    {
        _characterStats.CurrentStamina -= value;
        _characterReferences.CharacterUIStamina.SetCurrentStamina(_characterStats.CurrentStamina);
    }
}
