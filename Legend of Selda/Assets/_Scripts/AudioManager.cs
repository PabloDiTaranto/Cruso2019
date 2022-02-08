using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] audioTrack;
    public int currentTrack;
    public bool audioCanBePlayed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (audioCanBePlayed)
        {
            if (!audioTrack[currentTrack].isPlaying)
            {
                audioTrack[currentTrack].Play();
            }
        }
        else
        {
            audioTrack[currentTrack].Stop();
        }
    }

    public void PlayNewTrack(int newTrack)
    {
        audioTrack[currentTrack].Stop();
        currentTrack = newTrack;
        audioTrack[currentTrack].Play();
    }
}
