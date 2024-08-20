using System;
using Project.Scripts.Enemy;
using Project.Scripts.Units;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Project.Scripts.Configs.Spawn
{
    [Serializable]
    public abstract class SpawnData
    {
        [FormerlySerializedAs("_unit")]
        [FormerlySerializedAs("_enemyUnit")]
        [VerticalGroup("Main/Up")]
        [LabelWidth(100)]
        [PropertyOrder(1)]
        [LabelText("Prefab")]
        [SerializeField] private Units.Enemy _prefab;

        [VerticalGroup("Main/Down")]
        [LabelWidth(100)]
        [PropertyOrder(2)]
        [LabelText("SpawnChance")]
        [SerializeField] private int spawnChance;


        public Units.Enemy Prefab => _prefab;

        public int SpawnChance => spawnChance;

        public SpawnData(Units.Enemy prefab)
        {
            _prefab = prefab;
        }
    }
}