using System;
using ModestTree;
using Project.Scripts.Weapons;
using TMPro;
using UniRx;
using UnityEngine;

namespace Project.Scripts.UI
{
    public class SwitchWeaponTimeUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        private WeaponSwitcher _weaponSwitcher;

        private CompositeDisposable _disposable = new();
        
        private void Awake()
        {
            _weaponSwitcher = FindObjectOfType<WeaponSwitcher>();
        }

        private void Start()
        {
            _weaponSwitcher.SwtichWeaponTime.Subscribe(v =>
            {
                _textMeshPro.text = v.ToString();
                if (v <= 0)
                {
                    _textMeshPro.gameObject.SetActive(false);
                }
                else
                {
                    _textMeshPro.gameObject.SetActive(true);
                }
            }).AddTo(_disposable);
        }

        private void OnDestroy()
        {
            _disposable?.Clear();
        }
    }
}