using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealthManager : MonoBehaviour
{
    CharacterStats _characterStats;
    CharacterReferences _characterReferences;

    void Start()
    //Usually, you want to initialize scripts in the Awake() method.
    //However, due to Unity's execution order, you need to use the Start() method here, so it doesn't crash.
    {
        _characterStats = GetComponent<CharacterStats>();
        _characterReferences = GetComponent<CharacterReferences>();
        _characterReferences.CharacterUIHealthManager.SetMaxHealth(_characterStats.CurrentHealth);
        _characterReferences.CharacterUIHealthManager.SetCurrentHealth(_characterStats.CurrentHealth);
    }
    void Update()
    {
        if (_characterStats.CurrentHealth <= 0)
        {
            StartCoroutine(CheckDeath());
        }
    }
    IEnumerator CheckDeath()
    {
        _characterReferences.DeathTextUI.SetActive(true);
        _characterReferences.BattleThemeSource.Stop();
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(1);
    }
    public void PlayerRecieveDamage(float value)
    //This is a public method since it needs to be accessed from other objects
    {
        _characterStats.CurrentHealth -= value - _characterStats.ArmorAmount;
        _characterReferences.CharacterUIHealthManager.SetCurrentHealth(_characterStats.CurrentHealth);
    }
}