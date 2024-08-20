using System.Collections.Generic;
using Project.Scripts.Enemy;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Scripts.Configs.Spawn
{
    [CreateAssetMenu(fileName = "EnemiesSpawnConfig", menuName = "Configs/Spawn")]
    public class EnemiesSpawnConfig : SerializedScriptableObject
    {
        [ListDrawerSettings(ShowFoldout = true, DraggableItems = false, HideRemoveButton = true)]
        [SerializeField]
        private List<TypedSpawnData<EEnemyType>> _data = new();

        [SerializeField] private int _enemyCount;

        public int EnemyCount => _enemyCount;
        
        public List<TypedSpawnData<EEnemyType>> Data => _data;

    }
}