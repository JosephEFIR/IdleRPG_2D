using System;
using Project.Scripts.Configs;
using UnityEngine;

namespace Project.Scripts.Units
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] private UnitConfig _config;

        public UnitConfig Config => _config;
    }
}