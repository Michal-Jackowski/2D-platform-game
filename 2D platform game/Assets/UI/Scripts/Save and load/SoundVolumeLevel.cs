using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVolumeLevel : MonoBehaviour
{
    public int musicVolume;
    
    public void SavePlayerPosition()
    {
        SaveSystem.SaveSoundVolume(this);
    }

    public void LoadPlayerPosition()
    {
        SoundVolumeLevelData data = SaveSystem.LoadSoundVolume();

        musicVolume = data.musicVolume;
    }
}