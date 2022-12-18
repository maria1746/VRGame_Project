using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip backGroundMusic;
    
    void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
        
        InvokeRepeating("MusicStart", 0f, 146f);
    }

    void MusicStart()
    {
        audioSource.clip = backGroundMusic;
        audioSource.Play();
    }
}
