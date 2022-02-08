using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioTrack : MonoBehaviour
{
    private AudioManager _audioManager;

    public int trackID;

    public bool playOnStart;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        if (playOnStart)
        {
            _audioManager.PlayNewTrack(trackID);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _audioManager.PlayNewTrack(trackID);
            gameObject.SetActive(false);
        }
    }
}
