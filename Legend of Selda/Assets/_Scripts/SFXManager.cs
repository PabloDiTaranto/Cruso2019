using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    private static SFXManager sharedInstance;

    private List<GameObject> audios;

    public static SFXManager SharedInstance
    {
        get
        {
            return sharedInstance;
        }
    }

    private void Awake()
    {
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }

        sharedInstance = this;
        DontDestroyOnLoad(gameObject);

        audios = new List<GameObject>();
        
        foreach (Transform t in transform)
        {
            audios.Add(t.gameObject);
        }
    }

    private void Start()
    {
       
    }

    public AudioSource FindAudioSource(SFXType.SoundType type)
    {
        foreach (GameObject g in audios)
        {
            if (g.GetComponent<SFXType>().type == type)
            {
                return g.GetComponent<AudioSource>();
            }
        }

        return null;
    }

    public void PlaySFX(SFXType.SoundType type)
    {
        FindAudioSource(type).Play();
    }
}
