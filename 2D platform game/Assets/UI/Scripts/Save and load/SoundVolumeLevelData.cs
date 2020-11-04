using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVolumeLevelData
{
    public int musicVolume;

    public SoundVolumeLevelData(SoundVolumeLevel soundVolumeLevel)
    {
        musicVolume = soundVolumeLevel.musicVolume;
    }
}
