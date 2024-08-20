using UnityEngine;
using Zenject;

namespace Project.Scripts.INFO
{
    public class SaveLoadManager
    {
        public PlayerInfoData PlayerInfo;
        
        //[Inject]
        public void LoadData()
        {
            PlayerInfo = SaveSystem.LoadPlayerInfo(ESaveData.Player);
        }

        public void SaveData(ESaveData data)
        {
            switch (data)
            {   
                case ESaveData.Player:
                    SaveSystem.SavePlayerInfo(ESaveData.Player, PlayerInfo);
                    break;
                default:
                    Debug.LogError("Save data Error");
                    break;
            }
        }
    }
}