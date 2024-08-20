using Project.Scripts.Health;
using Project.Scripts.Spawn;
using Project.Scripts.Weapons;
using UniRx;
using Zenject;

namespace Project.Scripts.Common
{
    public class PlayerAutoAttacker : BaseAutoAttacker
    {
        
        [Inject] private EnemySpawner _enemySpawner;
        protected override void Awake()
        {
            _animator = GetComponent<PlayerAnimator>();
            base.Awake();
        }
        
        protected override void Init()
        {
            if (CompareTag("Player"))
            {
                WeaponSwitcher weaponSwitcher = GetComponentInChildren<WeaponSwitcher>();

                weaponSwitcher.CurrentWeapon.Subscribe(v =>
                {
                    damage = v.Config.Damage;
                }).AddTo(_disposable);
                
                _enemySpawner.CurrentEnemy.Subscribe(v =>
                {
                    _targetHealthComponent = v.GetComponent<HealthComponent>();
                    if (_targetHealthComponent.CurrentHealth.Value > 0)
                    {
                        StartAttack();
                    }
                } ).AddTo(_disposable);
            }
            base.Init();
        }
    }
}