using Project.Scripts.Weapons;
using UnityEngine;

namespace Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "PlayerInfoConfig", menuName = "Configs/PlayerInfo")]
     
    public class PlayerInfoConfig : ScriptableObject
    {
        [SerializeField] private Weapon _meleeWeapon;
        [SerializeField] private Weapon _rangeWeapon;
        [SerializeField] private int _level;
        
        public Weapon MeleeWeapon => _meleeWeapon;
        public Weapon RangeWeapon => _rangeWeapon;
        public int Level => _level;
    }
}