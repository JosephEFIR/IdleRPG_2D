using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "RootConfig",  menuName = "Configs/Root")]
    public class RootConfig : SerializedScriptableObject
    {
        [Range(30,60)]
        [SerializeField] private int _fps;
        [Range(0,3)]
        [SerializeField] private int _timeToPlay;
        [Range(1,5)]
        [SerializeField] private int _changeWeaponTime;
        
        public int FPS => _fps;
        public int TimeToPlay => _timeToPlay;
        public int ChangeWeaponTime => _changeWeaponTime;
    }
}