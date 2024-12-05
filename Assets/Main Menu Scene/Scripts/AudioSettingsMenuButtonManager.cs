
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsMenuButtonManager : MonoBehaviour
{
    public static float MusicVolumeSetting = 1;
    public static float SFXVolumeSetting = 1;
    [SerializeField]
    Slider _musicVolumeSlider;
    [SerializeField]
    Slider _sfxVolumeSlider;
    [SerializeField]
    GameObject _settingsMenu;

    public void MusicVolumeSliderChanged()
    {
        MusicVolumeSetting = _musicVolumeSlider.value;
    }
    public void SFXVolumeSliderChanged()
    {
        SFXVolumeSetting = _sfxVolumeSlider.value;
    }
    public void BackButton()
    {
        _settingsMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
