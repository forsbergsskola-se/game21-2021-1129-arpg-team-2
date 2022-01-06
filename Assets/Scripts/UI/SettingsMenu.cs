using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;



public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public TMP_Dropdown resolutionDropdown;
    

    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        

        resolutionDropdown.ClearOptions();
        //Clears all options in the resolution Drop down so we can add the computers on possible resolutions 

        int currentResulutionIndex = 0;
        List<string> options = new List<string>();
        // Creates List of strings that are gonna be the options 
        
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width  == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResulutionIndex = i;
            }
        }
        
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResulutionIndex;
        resolutionDropdown.RefreshShownValue();

    }   // AddOptions can only take string thats why we make teh array above 

    public void SetResolution(int resolutionIndex)
    {
        Debug.Log("Resolution Set");
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
