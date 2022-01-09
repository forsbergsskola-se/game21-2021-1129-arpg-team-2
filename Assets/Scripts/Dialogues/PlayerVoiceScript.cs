using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVoiceScript : MonoBehaviour
{
    public LayerMask PlayerLayer;
    [SerializeField] private float voiceRange = 5f;
    private bool isInRange;
    private AudioSource _audioClip;

    private void Start()
    {
        _audioClip = GetComponent<AudioSource>();
    }

    void Update()
    {
        isInRange = Physics.CheckSphere(transform.position, voiceRange, PlayerLayer);

        if (isInRange)
        {
            _audioClip.Play();
        }
    }
}
