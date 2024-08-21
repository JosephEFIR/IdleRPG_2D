using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Project.Scripts.Common;
using Project.Scripts.Configs;
using UniRx;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Weapons
{
    public class WeaponSwitcher : MonoBehaviour
    {
        [Inject] private PlayerInfoConfig _playerInfoConfig;
        [Inject] private RootConfig _rootConfig;
        
        private Weapon _meleeWeapon;
        private Weapon _rangeWeapon;
        //TODO Костыль скрипт? Зато работает идеально
        private WeaponHandler _weaponHandler;
        private PlayerAutoAttacker _playerAutoAttacker;
        private CancellationTokenSource _cancelToken;
        
        public readonly ReactiveProperty<int> SwtichWeaponTime = new ();
        public readonly ReactiveProperty<Weapon> CurrentWeapon = new();

        private Dictionary<EWeaponType, Weapon> _weapons = new();

        private void Awake()
        {
            _weaponHandler = GetComponent<WeaponHandler>();
            _playerAutoAttacker = GetComponentInParent<PlayerAutoAttacker>();

            Weapon[] weapons =
            {
                 Instantiate(_playerInfoConfig.MeleeWeapon, _weaponHandler.WeaponPoint),
                 Instantiate(_playerInfoConfig.RangeWeapon, _weaponHandler.WeaponPoint)
            };

            foreach (var weapon in weapons)
            {
                _weapons.Add(weapon.WeaponType, weapon);
                weapon.gameObject.SetActive(false);
            }

            CurrentWeapon.Value = _weapons[EWeaponType.Melee];
            CurrentWeapon.Value.gameObject.SetActive(true);
        }
        
        public void SwitchWeapon(EWeaponType weaponType)
        {
            CurrentWeapon.Value.gameObject.SetActive(false);
            
            SwtichWeaponTime.Value = _rootConfig.ChangeWeaponTime;
            _cancelToken = new CancellationTokenSource();

            CurrentWeapon.Value = _weapons[weaponType];
            CurrentWeapon.Value.gameObject.SetActive(true);
            
            _playerAutoAttacker.StopAttack();
            StayToChangeWeapon();
        }
        
        private async void StayToChangeWeapon()
        {
            while (SwtichWeaponTime.Value > 0)
            {
                await UniTask.Delay(1000, cancellationToken: _cancelToken.Token);
                SwtichWeaponTime.Value -= 1;
            }
            _playerAutoAttacker.StartAttack();
        }

        private void OnDestroy()
        {
            _cancelToken?.Cancel();
        }
    }
}