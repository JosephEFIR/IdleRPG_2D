using System;
using Project.Scripts.Common;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI
{
    public class CoolDownUI : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        
        private CompositeDisposable _disposable = new();
        private BaseAutoAttacker _baseAutoAttacker;
        private void Awake()
        {
            _baseAutoAttacker = GetComponentInParent<BaseAutoAttacker>();
        }

        private void Start()
        {
            _baseAutoAttacker.CoolDown.Subscribe(v =>
            {
                _slider.value = v;
            }).AddTo(_disposable);
        }

        private void OnDestroy()
        {
            _disposable?.Clear();
        }
    }
}