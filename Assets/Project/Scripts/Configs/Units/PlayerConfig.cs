using Project.Scripts.Hero;
using UnityEngine;

namespace Project.Scripts.Configs
{
    
    [CreateAssetMenu(fileName = "HeroConfig",  menuName = "Configs/Hero")]
    public class PlayerConfig : UnitConfig
    {
        [SerializeField]
        private EHeroType _heroType = EHeroType.Blue;        
        
        public EHeroType HeroType => _heroType;
    }
}