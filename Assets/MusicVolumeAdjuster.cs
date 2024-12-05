
using UnityEngine;

public class MusicVolumeAdjuster : MonoBehaviour
{
    AudioSource _audioSource;
    float _initialVolume;
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _initialVolume = _audioSource.volume;
    }
    void Update()
    {
        _audioSource.volume = _initialVolume * AudioSettingsMenuButtonManager.MusicVolumeSetting;
    }
}
