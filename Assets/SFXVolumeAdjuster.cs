using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXVolumeAdjuster : MonoBehaviour
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
        _audioSource.volume = _initialVolume * AudioSettingsMenuButtonManager.SFXVolumeSetting;
    }
}
