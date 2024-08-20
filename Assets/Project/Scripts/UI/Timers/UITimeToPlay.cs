using System;
using Cysharp.Threading.Tasks;
using Project.Scripts.Common;
using Project.Scripts.Configs;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Project.Scripts.UI
{
    public class UITimeToPlay : MonoBehaviour
    {
        [Inject] private RootConfig _rootConfig;
        
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        public ReactiveProperty<int> Time { get; private set; } = new();

        private CompositeDisposable _disposable = new();

        private void Start()
        {
            Time.Value = _rootConfig.TimeToPlay;
            Time.Subscribe(v =>
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
            Timer().Forget();
        }

        private void OnDestroy()
        {
            _disposable?.Clear();
        }
        
        private async UniTask Timer()
        {
            while (Time.Value > 0)
            {
                await UniTask.Delay(1000);
                Time.Value -= 1;
            }
        } 
    }
}