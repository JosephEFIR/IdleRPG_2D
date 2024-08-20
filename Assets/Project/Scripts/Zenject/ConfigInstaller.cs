using Project.Scripts.Configs;
using Project.Scripts.Configs.Audio;
using Project.Scripts.Configs.Spawn;
using UnityEngine;
using Zenject;

public class ConfigInstaller : MonoInstaller
{
    [SerializeField] private RootConfig _root;
    [SerializeField] private EnemiesSpawnConfig _enemiesSpawnConfig;
    [SerializeField] private AudioConfig _audioConfig;
    [SerializeField] private PlayerInfoConfig _playerInfoConfig;
    
    public override void InstallBindings()
    {
        Container.BindInstance(_root).AsSingle().NonLazy();
        Container.BindInstance(_enemiesSpawnConfig).AsSingle().NonLazy();
        Container.BindInstance(_audioConfig).AsSingle().NonLazy();
        Container.BindInstance(_playerInfoConfig).AsSingle().NonLazy();
    }
}