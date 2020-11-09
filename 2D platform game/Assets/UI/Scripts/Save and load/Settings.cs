using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class Settings : MonoBehaviour
{
    [Header("Sound Menu Sliders")]
    public Slider musicVolumeSlider;
    public Slider ambientVolumeSlider;
    public Slider stingVolumeSlider;
    public Slider playerVolumeSlider;
    public Slider voiceVolumeSlider;
    public Slider uiVolumeSlider;


    [Header("Graphic Menu Objects")]
    public Slider brightnessVolumeSlider;
    public GameObject isFullScreenToggleCheckmark;

    
    [Header("Sound Menu Sliders Volume Level")]
    public float musicVolumeLevel;
    public float ambientVolumeLevel;
    public float stingVolumeLevel;
    public float playerVolumeLevel;
    public float voiceVolumeLevel;
    public float uiVolumeLevel;


    [Header("Graphic Menu Objects Level")]
    public float brightnessVolumeLevel;
    public bool isFullScreen;
    public bool isPostProcessingOn;


    [Header("Menu Objects")]
    public GameObject settingMenu;
    public GameObject mainMenu;
    public GameObject soundMenu;
    public GameObject graphicMenu;


    //Variables used to save and load
    bool canSave = true;
    bool canLoad = true;

    void Start()
    {
        LoadPlayerSettings();
    }
    
    void Update()
    {
        if (mainMenu.activeSelf == true)
        {
            canSave = true;
            canLoad = true;
        }
        else if (settingMenu.activeSelf == true && canSave)
        {
            SavePlayerSettings();
            canSave = false;
            canLoad = true;
        }
        else if (soundMenu.activeSelf == true && canLoad)
        {
            LoadPlayerSettings();
            canLoad = false;
            canSave = true;
        }
        else if (graphicMenu.activeSelf == true && canLoad)
        {
            LoadPlayerSettings();
            canLoad = false;
            canSave = true;
        }
    }

    public void SavePlayerSettings()
    {
        SetVolumeLevel();
        SaveSystem.SaveSoundVolume(this);
        SetVolumeLevelSlider();
        //GetGraphicsSettings();
        //SetGraphicsSettings();
    }

    public void LoadPlayerSettings()
    {
        try
        {
            SettingsData data = SaveSystem.LoadSoundVolume();
            brightnessVolumeLevel = data.brightnessVolumeLevel;
            musicVolumeLevel = data.musicVolumeLevel;
            ambientVolumeLevel = data.ambientVolumeLevel;
            stingVolumeLevel = data.stingVolumeLevel;
            playerVolumeLevel = data.playerVolumeLevel;
            voiceVolumeLevel = data.voiceVolumeLevel;
            uiVolumeLevel = data.uiVolumeLevel;
            //Screen.fullScreen = data.isFullScreen;
            SetVolumeLevelSlider();
            //SetGraphicsSettings();
        }
        catch (NullReferenceException)
        {
            Debug.Log("Defualt save loaded");
        }
    }

    public void SetVolumeLevel()
    {
        musicVolumeLevel = musicVolumeSlider.value; 
        ambientVolumeLevel = ambientVolumeSlider.value;
        stingVolumeLevel = stingVolumeSlider.value;
        playerVolumeLevel = playerVolumeSlider.value;
        voiceVolumeLevel = voiceVolumeSlider.value;
        uiVolumeLevel = uiVolumeSlider.value;
        brightnessVolumeLevel = brightnessVolumeSlider.value;
    }

    public void SetVolumeLevelSlider()
    {
        musicVolumeSlider.value = musicVolumeLevel;
        ambientVolumeSlider.value = ambientVolumeLevel;
        stingVolumeSlider.value = stingVolumeLevel;
        playerVolumeSlider.value = playerVolumeLevel;
        voiceVolumeSlider.value = voiceVolumeLevel;
        uiVolumeSlider.value = uiVolumeLevel;
        brightnessVolumeSlider.value = brightnessVolumeLevel;
    }

    //Load/Save fullscreen state to fix
/*     public void GetGraphicsSettings()
    {
        isFullScreen = Screen.fullScreen;
    }

    public void SetGraphicsSettings()
    {
        Screen.fullScreen = isFullScreen;
    } */
}