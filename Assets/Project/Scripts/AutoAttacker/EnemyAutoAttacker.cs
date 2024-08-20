using Project.Scripts.Configs;
using Project.Scripts.Health;
using Project.Scripts.Units;

namespace Project.Scripts.Common
{
    public class EnemyAutoAttacker : BaseAutoAttacker
    {
        protected override void Awake()
        {
            _animator = GetComponent<EnemyAnimator>();
            base.Awake();
        }
        
        protected override void Init()
        {
            if (CompareTag("Enemy"))
            {
                Player player = FindObjectOfType<Player>();
                _targetHealthComponent = player.GetComponent<HealthComponent>();
                damage = _unitConfig.UnitStats[EUnitStat.Damage];
            }
            base.Init();
        }
    }
}