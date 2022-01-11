using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] string volumeParameter;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider slider;
    

    private void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    // public void Start()
    // {
    //     slider.value = PlayerPrefs.GetFloat(volumeParameter, slider.value);
    // }

    // private void OnDisable()
    // {
    //     PlayerPrefs.SetFloat(volumeParameter, slider.value);
    // }

    private void HandleSliderValueChanged(float value)
    {
        audioMixer.SetFloat(volumeParameter, value);
    }
}
