
using UnityEngine;

public class EntityAudioManager : MonoBehaviour
{
    AudioSource _audioSource;
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip audioClip, float volume, float pitch, float spatialBlend, bool loop)
    {
        _audioSource.clip = audioClip;
        _audioSource.volume = volume * AudioSettingsMenuButtonManager.SFXVolumeSetting;
        _audioSource.pitch = pitch;
        _audioSource.spatialBlend = spatialBlend;
        _audioSource.loop = loop;
        _audioSource.Play();
    }
    public void StopSound()
    {
        _audioSource.Stop();
    }
}
