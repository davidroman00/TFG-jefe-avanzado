
using UnityEngine;

public class SettingsMenuButtonManager : MonoBehaviour
{
    [SerializeField]
    GameObject _mainMenu;
    [SerializeField]
    GameObject _audioSettingsMenu;
    [SerializeField]
    GameObject _videoSettingsMenu;
    [SerializeField]
    GameObject _keybindSettingsMenu;

    public void AudioSettingsButton()
    {
        gameObject.SetActive(false);
        _audioSettingsMenu.SetActive(true);
    }
    public void VideoSettingsButton()
    {
        gameObject.SetActive(false);
        _videoSettingsMenu.SetActive(true);
    }
    public void KeybindSettingsButton()
    {
        gameObject.SetActive(true);
        _keybindSettingsMenu.SetActive(false);
    }
    public void BackButton()
    {
        gameObject.SetActive(false);
        _mainMenu.SetActive(true);
    }
}
