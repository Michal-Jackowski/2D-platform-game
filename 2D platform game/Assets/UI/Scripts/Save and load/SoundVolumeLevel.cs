using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class SoundVolumeLevel : MonoBehaviour
{
    [Header("Sound Menu Sliders")]
    public Slider musicVolumeSlider;
    public Slider ambientVolumeSlider;
    public Slider stingVolumeSlider;
    public Slider playerVolumeSlider;
    public Slider voiceVolumeSlider;
    public Slider uiVolumeSlider;

    
    [Header("Sound Menu Sliders Volume Level")]
    public float musicVolumeLevel;
    public float ambientVolumeLevel;
    public float stingVolumeLevel;
    public float playerVolumeLevel;
    public float voiceVolumeLevel;
    public float uiVolumeLevel;
    


    [Header("Menu Objects")]
    public GameObject settingMenu;
    public GameObject mainMenu;
    public GameObject soundMenu;


    //Variables used to save and load
    bool canSave = true;
    bool canLoad = true;

    void Start()
    {
        LoadPlayerPlayerMusicAudioLevel();
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
            SavePlayerMusicAudioLevel();
            canSave = false;
            canLoad = true;
        }
        else if(soundMenu.activeSelf == true && canLoad)
        {
            LoadPlayerPlayerMusicAudioLevel();
            canLoad = false;
            canSave = true;
        }
    }

    public void SavePlayerMusicAudioLevel()
    {
        SetMusicVolumeLevel();
        SaveSystem.SaveSoundVolume(this);
        SetMusicVolumeLevelSlider();
    }

    public void LoadPlayerPlayerMusicAudioLevel()
    {
        try
        {
            SoundVolumeLevelData data = SaveSystem.LoadSoundVolume();
            musicVolumeLevel = data.musicVolumeLevel;
            SetMusicVolumeLevelSlider();
        }
        catch (NullReferenceException)
        {
            Debug.Log("Defualt save loaded");
        }
    }

    public void SetMusicVolumeLevel()
    {
        musicVolumeLevel = musicVolumeSlider.value;
    }

    public void SetMusicVolumeLevelSlider()
    {
        musicVolumeSlider.value = musicVolumeLevel;
    }
}