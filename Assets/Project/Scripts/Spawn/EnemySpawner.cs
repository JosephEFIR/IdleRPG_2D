using System;
using System.Collections.Generic;
using System.Linq;
using Project.Scripts.Configs.Spawn;
using Project.Scripts.Factory;
using UniRx;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Project.Scripts.Spawn
{
    public class EnemySpawner : MonoBehaviour
    {
        [Inject] private UnitFactory _unitFactory;
        [Inject] private EnemiesSpawnConfig _enemiesSpawnConfig;
        
        private Dictionary<Units.Enemy, int> _enemySpawnChance = new();
        [NonSerialized]
        public ReactiveProperty<Units.Enemy> CurrentEnemy = new();
        private List<Units.Enemy> _enemies = new(); //TODO а реактивный лист ?
        public ReactiveProperty<int> CountEnemies = new();

        private void Start()
        {
            foreach (var variable in _enemiesSpawnConfig.Data)
            {
                _enemySpawnChance.Add(variable.Prefab, variable.SpawnChance);
            }
            
            for (int i = 0; i < _enemiesSpawnConfig.EnemyCount; i++)
            {
                SpawnEnemy();
            }
            
            NextEnemy();
        }

        private void SpawnEnemy()
        {
            Units.Enemy enemyPrefab = GetEnemyOnChance();
            var enemy = _unitFactory.CreateEnemy(enemyPrefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            _enemies.Add(enemy);
            CountEnemies.Value++;
            enemy.gameObject.SetActive(false);
        }
        
        private void NextEnemy()
        {
            if (_enemies.Count == 0)
            {
                CountEnemies.Value = 0;
            }
            else
            {
                Units.Enemy enemy = _enemies[0];
                CurrentEnemy.Value = enemy;
                
                enemy.gameObject.SetActive(true);
            }
        }
        
        public void DestroyEnemy(Units.Enemy enemy)
        {
            _enemies.RemoveAt(0);
            CountEnemies.Value--;
            Destroy(enemy.gameObject);
            NextEnemy();
        }

        public Units.Enemy GetCurrentEnemy()
        {
            CurrentEnemy.Value = _enemies[0];
            return CurrentEnemy.Value;
        }

        private Units.Enemy GetEnemyOnChance()
         {
             int totalPercent = _enemySpawnChance.Values.Sum();
        
             int randomValue = Random.Range(0, totalPercent);
             int cumulativePercent = 0;
        
             foreach (var enemyPercent in _enemySpawnChance)
             {
                 cumulativePercent += enemyPercent.Value;
                 if (randomValue < cumulativePercent)
                 {
                     return enemyPercent.Key;
                 }
             }
             
             return null;
         }
        
    }
}