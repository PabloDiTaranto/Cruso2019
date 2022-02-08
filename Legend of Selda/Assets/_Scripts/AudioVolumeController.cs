using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioVolumeController : MonoBehaviour
{
    public enum AudioType{MUSIC, SFX}

    public AudioType type;
    private AudioSource _audioSource;
    private float currentAudioLevel;
    
    [Range(0,2f)]
    public float defaultAudioLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SetAudioLevel(float newAudiolevel)
    {
        if (_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>();
        }

        currentAudioLevel = defaultAudioLevel * newAudiolevel;
        _audioSource.volume = currentAudioLevel;
    }
}
