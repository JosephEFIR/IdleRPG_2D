using System;
using Project.Configs.Weapons;
using Project.Scripts.Common;
using UnityEngine;

namespace Project.Scripts.Weapons
{
    public enum EWeaponType
    {
        None,
        Melee,
        Range,
    }
    
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private EWeaponType _weaponType;
        [SerializeField] private WeaponConfig _config;
        
        public EWeaponType WeaponType => _weaponType;
        public WeaponConfig Config => _config;
        
        private Bullet _bullet;
        private PlayerAutoAttacker _playerAutoAttacker;

        private void Awake()
        {
            _bullet = GetComponentInChildren<Bullet>();
            _playerAutoAttacker = GetComponentInParent<PlayerAutoAttacker>();
        }

        private void OnEnable()
        {
            if (_weaponType == EWeaponType.Range)
            {
                _playerAutoAttacker.OnAttackEvent += Fire;
            }
        }
//TODO SUPER MEGA Костыль
        private void OnDisable()
        {
            if (_weaponType == EWeaponType.Range)
            {
                _playerAutoAttacker.OnAttackEvent -= Fire;
            }
        }

        private void Fire()
        {
            _bullet.gameObject.SetActive(true);
            _bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 1000, ForceMode2D.Force);
        }
    }
}