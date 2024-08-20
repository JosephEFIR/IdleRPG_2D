using System;
using Project.Scripts.Health;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _textMeshPro;

        private HealthComponent _healthComponent;
        private CompositeDisposable _disposable = new();

        private void Awake()
        {
            _healthComponent = GetComponentInParent<HealthComponent>();
        }

        private void Start()
        {
            _healthComponent.CurrentHealth.Subscribe(v =>
            {
                if (v < 0)
                {
                    v = 0;
                }
                _slider.value = v / _healthComponent.MaxHealth;
                _textMeshPro.text = v.ToString();
            }).AddTo(_disposable);
        }

        private void OnDestroy()
        {
            _disposable?.Clear();
        }
    }
}