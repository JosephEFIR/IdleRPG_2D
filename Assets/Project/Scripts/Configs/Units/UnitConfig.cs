using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Scripts.Configs
{
    public enum EUnitStat
    {
        Health,
        Armor,
        Damage,
        CoolDown,
        Luck
    }
    
    public class UnitConfig : SerializedScriptableObject
    {
        [ListDrawerSettings(ShowFoldout = true, DraggableItems = false, HideRemoveButton = true)]
        
        [SerializeField]
        private Dictionary<EUnitStat, float> _unitStats = new()
        {
            {EUnitStat.Health, 0},
            {EUnitStat.Armor, 0},
            {EUnitStat.Damage, 0},
            {EUnitStat.CoolDown, 0},
            {EUnitStat.Luck, 0}
        };

        public Dictionary<EUnitStat, float> UnitStats => _unitStats;
    }
}