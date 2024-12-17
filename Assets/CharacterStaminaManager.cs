using System.Collections;
using System.Collections.Generic;
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
        // _characterReferences.CharacterUIStaminaManager.SetMaxHealth(_characterStats.MaxStamina);
        // _characterReferences.CharacterUIStaminaManager.SetCurrentHealth(_characterStats.CurrentStamina);
    }    
    public void ReduceStamina(float value)
    //This is a public method since it needs to be accessed from other objects
    {
        _characterStats.CurrentStamina -= value;
        // _characterReferences.CharacterUIStaminaManager.SetCurrentStamina(_characterStats.CurrentStamina);
    }
}
