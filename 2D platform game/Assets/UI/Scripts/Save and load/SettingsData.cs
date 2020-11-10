using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingsData
{
    public float musicVolumeLevel;
    public float ambientVolumeLevel;
    public float stingVolumeLevel;
    public float playerVolumeLevel;
    public float voiceVolumeLevel;
    public float uiVolumeLevel;
    public float brightnessVolumeLevel;
    public bool isFullScreen;


    public SettingsData(Settings settings)
    {
        musicVolumeLevel = settings.musicVolumeLevel;
        ambientVolumeLevel = settings.ambientVolumeLevel;
        stingVolumeLevel = settings.stingVolumeLevel;
        playerVolumeLevel = settings.playerVolumeLevel;
        voiceVolumeLevel = settings.voiceVolumeLevel;
        uiVolumeLevel = settings.uiVolumeLevel;
        brightnessVolumeLevel = settings.brightnessVolumeLevel;
        isFullScreen = settings.isFullScreen;
    }
}
