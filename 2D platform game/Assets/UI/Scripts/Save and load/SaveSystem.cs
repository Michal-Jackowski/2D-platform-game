using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveSoundVolume(SoundVolumeLevel soundVolumeLevel)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = GetSaveDataName();
        FileStream stream = new FileStream(path, FileMode.Create);

        SoundVolumeLevelData data = new SoundVolumeLevelData(soundVolumeLevel);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SoundVolumeLevelData LoadSoundVolume()
    {
        string path = GetSaveDataName();
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SoundVolumeLevelData data = formatter.Deserialize(stream) as SoundVolumeLevelData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

    public static string GetSaveDataName()
    {
        string path = Application.persistentDataPath + "/GameSave.bin";
        return path;
    }
}
