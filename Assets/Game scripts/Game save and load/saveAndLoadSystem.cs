using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class saveAndloadsystem
{
    public static void SavePlayerData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saveFiles.Sharmoot";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);


        PlayerData data = new PlayerData();

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static PlayerData LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/saveFiles.Sharmoot";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
}