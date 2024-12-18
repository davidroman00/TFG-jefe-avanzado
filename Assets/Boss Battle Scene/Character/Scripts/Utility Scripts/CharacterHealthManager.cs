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
    public void CharacterModifyCurrentHealth(float value)
    //This is a public method since it needs to be accessed from other objects
    {
        if (value < 0 && _characterStats.CurrentHealth + value > _characterStats.MaxHealth)
        {
            _characterStats.CurrentHealth = _characterStats.MaxHealth;
        }
        if (value < 0 && _characterStats.CurrentHealth + value < _characterStats.MaxHealth)
        {
            _characterStats.CurrentHealth -= value;
        }
        if (value > 0 && value - _characterStats.ArmorAmount <= 1)
        {
            _characterStats.CurrentHealth -= 1;
        }
        if (value > 0 && value - _characterStats.ArmorAmount > 1)
        {
            _characterStats.CurrentHealth -= (value - _characterStats.ArmorAmount) * (1 - _characterStats.DamageBlocked / 100);
            if ((value - _characterStats.ArmorAmount) * (1 - _characterStats.DamageBlocked / 100) > _characterStats.StaggerProcDamageThreshold && !GetComponent<CharacterCooldownManager>().IsStaggerOnCooldown())
            {
                GetComponent<Animator>().SetTrigger("stagger");
            }
            if ((value - _characterStats.ArmorAmount) * (1 - _characterStats.DamageBlocked / 100) == 0)
            {
                //Play parry sound
            }
        }
        _characterReferences.CharacterUIHealthManager.SetCurrentHealth(_characterStats.CurrentHealth);
    }
}