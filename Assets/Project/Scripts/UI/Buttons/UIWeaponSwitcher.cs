using Project.Scripts.Weapons;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI
{
    public class UIWeaponSwitcher : MonoBehaviour
    {
        private WeaponSwitcher _weaponSwitcher;
        [SerializeField] private EWeaponType _weaponType;
        
        private CompositeDisposable _disposable = new();
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>(); 
            _weaponSwitcher = FindObjectOfType<WeaponSwitcher>();
        }

        private void Start()
        {
            _weaponSwitcher.CurrentWeapon.Subscribe(v =>
            {
                if (v.WeaponType == _weaponType)
                {
                    _button.interactable = false;
                }
                else
                {
                    _button.interactable = true;
                }
            }).AddTo(_disposable);

            _button.onClick.AddListener(WeaponSwitch);
        }

        private void WeaponSwitch()
        {
            _weaponSwitcher.SwitchWeapon(_weaponType);
        }

        private void OnDestroy()
        {
            _disposable?.Clear();
        }
    }
}