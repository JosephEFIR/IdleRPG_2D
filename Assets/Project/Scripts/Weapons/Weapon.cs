using System;
using Project.Configs.Weapons;
using Project.Scripts.Common;
using Project.Scripts.Units;
using UniRx;
using UnityEngine;

namespace Project.Scripts.Weapons
{
    public enum EWeaponType
    {
        None,
        Melee,
        Range,
    }
    
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private EWeaponType _weaponType;
        [SerializeField] private WeaponConfig _config;
        public EWeaponType WeaponType => _weaponType;

        public WeaponConfig Config => _config;
    }
}