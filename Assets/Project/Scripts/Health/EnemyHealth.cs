using Zenject;
using EnemySpawner = Project.Scripts.Spawn.EnemySpawner;

namespace Project.Scripts.Health
{
    public class EnemyHealth : HealthComponent
    {
        [Inject] private EnemySpawner _enemySpawner;

        protected override void OnDie()
        {
            _enemySpawner.DestroyEnemy(gameObject.GetComponent<Units.Enemy>());
        }
    }
}