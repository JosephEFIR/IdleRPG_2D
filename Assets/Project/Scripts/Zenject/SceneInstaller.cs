using Project.Scripts.Factory;
using Project.Scripts.Spawn;
using Project.Scripts.UI;
using Zenject;

namespace Project.Scripts.Zenject
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UnitFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<UITimeToPlay>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EnemySpawner>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<UIManager>().FromComponentInHierarchy().AsSingle();
        }
    }
}