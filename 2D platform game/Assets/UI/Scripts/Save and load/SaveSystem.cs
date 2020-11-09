using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SaveSystem
{
    public static void SaveSoundVolume(Settings soundVolumeLevel)
    {
        string path = GetPath();
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        SettingsData data = new SettingsData(soundVolumeLevel);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SettingsData LoadSoundVolume()
    {
        string path = GetPath();
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SettingsData data = formatter.Deserialize(stream) as SettingsData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }

    public static string GetPath()
    {
        string path = Application.persistentDataPath + "/GameSave.bin";
        return path;
    }
}
