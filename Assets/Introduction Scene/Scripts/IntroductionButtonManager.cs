using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroductionButtonManager : MonoBehaviour
{
    public static string Username;
    [SerializeField]
    GameObject _holaText;
    [SerializeField]
    GameObject _bienvenidaText;
    [SerializeField]
    GameObject _flamanteText;
    [SerializeField]
    GameObject _legendarioText;
    [SerializeField]
    GameObject _nombreText;
    [SerializeField]
    TMP_InputField _usernameInputField;
    [SerializeField]
    Button _confirmUsernameButton;
    int _currentAmountOfClicks;
    [SerializeField]
    float _waitTime;
    bool _isWaiting;

    void Awake()
    {
        _currentAmountOfClicks = 0;
    }
    void Update()
    {
        switch (_currentAmountOfClicks)
        {
            case 0:
                _holaText.SetActive(true);
                break;
            case 1:
                _holaText.SetActive(false);
                _bienvenidaText.SetActive(true);
                break;
            case 2:
                _bienvenidaText.SetActive(false);
                _flamanteText.SetActive(true);
                break;
            case 3:
                _flamanteText.SetActive(false);
                _legendarioText.SetActive(true);
                break;
            case 4:
                _legendarioText.SetActive(false);
                _nombreText.SetActive(true);
                break;
            case 5:
                _usernameInputField.gameObject.SetActive(true);
                if (_usernameInputField.text != "")
                {
                    _confirmUsernameButton.gameObject.SetActive(true);
                }
                else
                {
                    _confirmUsernameButton.gameObject.SetActive(false);
                }
                break;
        }
        HandleClickAmount();
    }
    void HandleClickAmount()
    {
        if (Input.anyKey && !_isWaiting && _currentAmountOfClicks < 5)
        {
            StartCoroutine(HandleWaitTime());
        }
    }
    IEnumerator HandleWaitTime()
    {
        _currentAmountOfClicks++;
        _isWaiting = true;
        yield return new WaitForSeconds(_waitTime);
        _isWaiting = false;
    }
    public void ConfirmUsername()
    {
        Username = _usernameInputField.text;
        SceneManager.LoadScene(1);
    }
}
