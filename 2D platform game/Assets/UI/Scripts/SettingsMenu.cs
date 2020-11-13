using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.PostProcessing;

public class SettingsMenu : MonoBehaviour
{
    public GameObject GraphicMenu;
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public TMP_Dropdown ResolutionDropdown;

    private void Start()
    {
        //Get resolutions
        int CurrentResolutionIndex = 0;
        resolutions = Screen.resolutions;

        ResolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string Option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(Option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                CurrentResolutionIndex = i;
            }
        }
        ResolutionDropdown.AddOptions(options);
        ResolutionDropdown.value = CurrentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("music volume", volume*4);
    }

    public void SetAmbientVolume(float volume)
    {
        audioMixer.SetFloat("ambient volume", volume*4);
    }

    public void SetStingVolume(float volume)
    {
        audioMixer.SetFloat("sting volume", volume*4);
    }

    public void SetPlayerVolume(float volume)
    {
        audioMixer.SetFloat("player volume", volume*4);
    }

    public void SetVoiceVolume(float volume)
    {
        audioMixer.SetFloat("voice volume", volume*4);
    }

    public void SetUIVolume(float volume)
    {
        audioMixer.SetFloat("ui volume", volume*4);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}