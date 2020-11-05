using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundVolumeLevelData
{
    public float musicVolumeLevel;

    public SoundVolumeLevelData(SoundVolumeLevel soundVolumeLevel)
    {
        musicVolumeLevel = soundVolumeLevel.musicVolumeLevel;
    }
}
