using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Project.Scripts.Units;
using UnityEngine;

namespace Project.Scripts.INFO
{
    public static class SaveSystem
    {
        public static void SavePlayerInfo(ESaveData data, PlayerInfoData playerInfo)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + $"{data}.fun";
            FileStream stream = new FileStream(path, FileMode.Create);
            
            formatter.Serialize(stream, playerInfo);
            stream.Close();
        }

        public static PlayerInfoData LoadPlayerInfo(ESaveData data)
        {
            string path = Application.persistentDataPath + $"{data}.fun";
            
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                
                PlayerInfoData playerData = formatter.Deserialize(stream) as PlayerInfoData;
                stream.Close();

                return playerData;
            }

            Debug.LogError("File not found " + path);
            return null;
        }
    }
}