using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundVolumeLevel : MonoBehaviour
{
    public Slider mainSlider;
    public float musicVolumeLevel;


    public void SavePlayerMusicAudioLevel()
    {
        SetMusicVolumeLevel();
        Debug.Log("Poziom musicSound = " + musicVolumeLevel);
        SaveSystem.SaveSoundVolume(this);
    }

    public void LoadPlayerPlayerMusicAudioLevel()
    {
        SoundVolumeLevelData data = SaveSystem.LoadSoundVolume();

        musicVolumeLevel = data.musicVolumeLevel;
    }

    public void SetMusicVolumeLevel()
    {
        musicVolumeLevel = mainSlider.value;
        musicVolumeLevel = Mathf.Round(musicVolumeLevel) * 4;
    }
}