﻿using System.Collections;
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


    [Header("Graphics Menu Objects")]
    public Slider brightnessVolumeSlider;


    [Header("Sound Menu Sliders Volume Level")]
    public float musicVolumeLevel;
    public float ambientVolumeLevel;
    public float stingVolumeLevel;
    public float playerVolumeLevel;
    public float voiceVolumeLevel;
    public float uiVolumeLevel;


    [Header("Graphics Menu Objects Level")]
    public float brightnessVolumeLevel;
    public bool isFullScreen;


    [Header("Menu Objects")]
    public GameObject settingMenu;
    public GameObject mainMenu;
    public GameObject soundMenu;
    public GameObject graphicMenu;


    //Variables used to save and load
    bool canSave = true;
    bool canLoad = true;
    bool defaultSettings;
    public bool isPostProcessingManagerOn;
    public GameObject fullScreenToggle;
    public GameObject PostProcessingToggle;
    public GameObject PostProcessingManager;


    void Start()
    {
        defaultSettings = false;
        LoadPlayerSettings();
        SetCorrectToggleState();
        SetPostProcessingManager();
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
        GetVolumeLevel();
        SetVolumeLevelSlider();
        GetGraphicsSettings();
        SaveSystem.SaveSoundVolume(this);
    }

    public void LoadPlayerSettings()
    {
        try
        {
            SettingsData data = SaveSystem.LoadSoundVolume();
            isFullScreen = data.isFullScreen;
            isPostProcessingManagerOn = data.isPostProcessingManagerOn;
            brightnessVolumeLevel = data.brightnessVolumeLevel;
            musicVolumeLevel = data.musicVolumeLevel;
            ambientVolumeLevel = data.ambientVolumeLevel;
            stingVolumeLevel = data.stingVolumeLevel;
            playerVolumeLevel = data.playerVolumeLevel;
            voiceVolumeLevel = data.voiceVolumeLevel;
            uiVolumeLevel = data.uiVolumeLevel;
            SetVolumeLevelSlider();
        }
        catch (NullReferenceException)
        {
            Debug.Log("Default save loaded");
            defaultSettings = true;
        }
    }

    public void GetVolumeLevel()
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

    public void GetGraphicsSettings()
    {
        isFullScreen = Screen.fullScreen;
        isPostProcessingManagerOn = PostProcessingToggle.GetComponent<UnityEngine.UI.Toggle>().isOn;
    }

    public void SetCorrectToggleState()
    {
        if(!defaultSettings)
        {
            fullScreenToggle.GetComponent<UnityEngine.UI.Toggle>().isOn = isFullScreen;
            PostProcessingToggle.GetComponent<UnityEngine.UI.Toggle>().isOn = isPostProcessingManagerOn;
        }
    }

    public void SetPostProcessingManager()
    {
        if(!defaultSettings)
        {
            PostProcessingManager.SetActive(isPostProcessingManagerOn);
            if(!isPostProcessingManagerOn)
            {
                PauseMenuManagerNew.postProcessingEnabled = false;
                MenuManager.postProcessingEnabled = false;
            }
        }
    }
}