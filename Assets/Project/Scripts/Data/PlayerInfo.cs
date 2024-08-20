using Project.Scripts.Weapons;
using UnityEngine.Serialization;

namespace Project.Scripts.INFO
{
    [System.Serializable]
    public class PlayerInfoData
    {
        public EWeaponType MeleeWeapon;
        public EWeaponType RangeWeapon;
        public int PlayerLevel;
    }
}