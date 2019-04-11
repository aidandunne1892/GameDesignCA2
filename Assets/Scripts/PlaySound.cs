using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioClip SoundToPlay;
    public float Volume;
    AudioSource audio;
    public bool alreadyPlayed = false;



    void Start()
    {
        audio = GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (!alreadyPlayed && other.gameObject.CompareTag("Player"))
        {
            audio.PlayOneShot(SoundToPlay, Volume);
            alreadyPlayed = true;
        }
    }
}
