using System;
using Cysharp.Threading.Tasks;
using Project.Scripts.Health;
using Project.Scripts.UI;
using Project.Scripts.Units;
using UniRx;
using UnityEngine;
using Zenject;
using EnemySpawner = Project.Scripts.Spawn.EnemySpawner;

namespace Project.Scripts.Common
{
    public class GameManager : MonoBehaviour
    {
        [Inject] private EnemySpawner _enemySpawner;
        [Inject] private UIManager _uiManager;

        private Player _player;
        private CompositeDisposable _disposable = new();
        private async void Start()
        {
            await UniTask.Delay(1000); //TODO ну тут мои полномочия все
            
            _player = FindObjectOfType<Player>();
            
            _enemySpawner.CountEnemies.Subscribe(v =>
            {
                if (v == 0)
                {
                    _uiManager.SetScreen(EScreenType.Victory);
                }
            }).AddTo(_disposable);
            
            _player.GetComponent<HealthComponent>().CurrentHealth.Subscribe(v =>
            {
                if (v <= 0)
                {
                    _uiManager.SetScreen(EScreenType.Failed);
                }
            }).AddTo(_disposable);
        }

        private void OnDestroy()
        {
            _disposable?.Clear();
        }
    }
}