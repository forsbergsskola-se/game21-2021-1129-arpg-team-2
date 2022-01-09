using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVoiceScript : MonoBehaviour
{
    private bool alreadyPlayed;
    private AudioSource _audioClip;
    

    private void Start()
    {
        _audioClip = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (alreadyPlayed == false)
        {
            _audioClip.Play();
            alreadyPlayed = true;
        }
        

    }
}
