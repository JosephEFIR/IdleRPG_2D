using UnityEngine;

namespace Project.Scripts.Weapons
{
    public class WeaponHandler : MonoBehaviour
    {
        [SerializeField] private Transform _weaponPoint;

        public Transform WeaponPoint => _weaponPoint;
        //TODO уже не успею переделать. можно не этот transform менять а менять уже саму позицию weaponHandler...
    }
}