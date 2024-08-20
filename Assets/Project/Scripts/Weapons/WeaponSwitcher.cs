using System;
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

        public ReactiveProperty<int> SwtichWeaponTime = new ();
        
        [NonSerialized] public ReactiveProperty<Weapon> CurrentWeapon = new();

        private void Awake()
        {
            _weaponHandler = GetComponent<WeaponHandler>();
            _playerAutoAttacker = GetComponentInParent<PlayerAutoAttacker>();
            
            _meleeWeapon = Instantiate(_playerInfoConfig.MeleeWeapon, _weaponHandler.WeaponPoint);
            _rangeWeapon = Instantiate(_playerInfoConfig.RangeWeapon, _weaponHandler.WeaponPoint);
            
            _rangeWeapon.gameObject.SetActive(false);
            
            CurrentWeapon.Value = _meleeWeapon;
        }
        
        public void PickMeleeWeapon()
        {
            SwtichWeaponTime.Value = _rootConfig.ChangeWeaponTime;
            _cancelToken = new CancellationTokenSource();
            
            _rangeWeapon.gameObject.SetActive(false);
            _meleeWeapon.gameObject.SetActive(true);
            
            CurrentWeapon.Value = _meleeWeapon;
            _playerAutoAttacker.StopAttack();
            StayToChangeWeapon();
        }
        public void PickRangeWeapon()
        {
            SwtichWeaponTime.Value = _rootConfig.ChangeWeaponTime;
            _cancelToken = new CancellationTokenSource();
            
            _rangeWeapon.gameObject.SetActive(true);
            _meleeWeapon.gameObject.SetActive(false);
            
            CurrentWeapon.Value = _rangeWeapon;
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