
using UnityEngine;

public class BossAudioManager : MonoBehaviour
{
    AudioSource _audioSource;
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void PlayBossSound(AudioClip audioClip, float volume, float pitch, float spatialBlend, bool loop)
    {
        _audioSource.clip = audioClip;
        _audioSource.volume = volume;
        _audioSource.pitch = pitch;
        _audioSource.spatialBlend = spatialBlend;
        _audioSource.loop = loop;
        _audioSource.Play();
    }
}
