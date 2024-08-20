using Project.Scripts.Enemy;
using UnityEngine;

namespace Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig",  menuName = "Configs/Enemy")]
    
    public class EnemyConfig : UnitConfig
    {
        [SerializeField]
        private EEnemyType _enemyType = EEnemyType.Samurai;

        public EEnemyType EnemyType => _enemyType;
    }
}