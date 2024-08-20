using UnityEngine;

namespace Project.Configs.Weapons
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Configs/Weapon")]
    public class WeaponConfig : ScriptableObject
    {
        [SerializeField] private int _damage;

        public int Damage => _damage; //TODO SAVE SYSTEM WEAPON AND PROGRESS!
    }
}