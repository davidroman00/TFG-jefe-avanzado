
using UnityEngine;

public class SettingsMenuButtonManager : MonoBehaviour
{
    [SerializeField]
    GameObject _mainMenu;
    [SerializeField]
    GameObject _settingsMenu;
    [SerializeField]
    GameObject _audioSettingsMenu;
    [SerializeField]
    GameObject _videoSettingsMenu;
    [SerializeField]
    GameObject _keybindSettingsMenu;

    public void AudioSettingsButton()
    {
        _settingsMenu.SetActive(false);
        _audioSettingsMenu.SetActive(true);
    }
    public void VideoSettingsButton()
    {
        _settingsMenu.SetActive(false);
        _videoSettingsMenu.SetActive(true);
    }
    public void KeybindSettingsButton()
    {
        _settingsMenu.SetActive(true);
        _keybindSettingsMenu.SetActive(false);
    }
    public void BackButton()
    {
        _settingsMenu.SetActive(false);
        _mainMenu.SetActive(true);
    }
}
