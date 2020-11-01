using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayerPosition(PlayerPosition playerPosition)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = GetSaveDataName();
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerPositionData data = new PlayerPositionData(playerPosition);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerPositionData LoadPlayerPosition()
    {
        string path = GetSaveDataName();
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerPositionData data = formatter.Deserialize(stream) as PlayerPositionData;
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
