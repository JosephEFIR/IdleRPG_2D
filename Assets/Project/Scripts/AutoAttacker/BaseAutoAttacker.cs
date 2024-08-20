using System.Threading;
using Cysharp.Threading.Tasks;
using Project.Scripts.Configs;
using Project.Scripts.Configs.Audio;
using Project.Scripts.Health;
using Project.Scripts.UI;
using UniRx;
using UnityEngine;
using Zenject;
using Unit = Project.Scripts.Units.Unit;

namespace Project.Scripts.Common
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class BaseAutoAttacker : MonoBehaviour
    {
        [Inject] private AudioConfig _audioConfig;
        [Inject] private UITimeToPlay _timeToPlay;

        protected BaseAnimator _animator;
        private AudioSource _audioSource;
        
        public ReactiveProperty<float> CoolDown { get;} = new();
        protected float damage { get; set; }
        protected float reloadTime;

        protected CompositeDisposable _disposable = new();
        
        private Unit _unit;
        protected UnitConfig _unitConfig;
        protected HealthComponent _targetHealthComponent;

        private CancellationTokenSource _cancelToken;

        protected virtual void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _unit = GetComponent<Unit>();
            _unitConfig = _unit.Config;
        }

        private void Start()
        {
            Init();
        }
        
        protected virtual void Init()
        {
            reloadTime = _unitConfig.UnitStats[EUnitStat.CoolDown];
            CoolDown.Value = reloadTime;
            
            _timeToPlay.Time.Subscribe(v =>
            {
                if (v <= 0)
                {
                    StartAttack();
                }
            }).AddTo(_disposable);
        }
        
        public void StartAttack()
        {
            Debug.Log("attack " + gameObject.name);
            if (_targetHealthComponent.CurrentHealth.Value <= 0)
            {
                StopAttack();
            }
            
            _animator.PlayAnim(EAnimationsType.Attack);
            _audioSource.clip = _audioConfig.BattleAudioClips[EBattleAudio.SwordSwing];
            _audioSource.Play();
        }

        private void OnAttack()
        { 
            _targetHealthComponent.GetDamage(damage);
            _audioSource.clip = _audioConfig.BattleAudioClips[EBattleAudio.SwordHit];
            _audioSource.Play();
    
            _animator.PlayAnim(EAnimationsType.Idle);
            _cancelToken = new CancellationTokenSource();
            Reload().Forget();
        }

        private async UniTask Reload()
        {
            CoolDown.Value = reloadTime;

            while (CoolDown.Value > 0)
            {
                await UniTask.Delay(100, cancellationToken:_cancelToken.Token);
                CoolDown.Value -= 0.1F;
            }

            CoolDown.Value = 0;
            StartAttack();
        }

        public void StopAttack()
        {
            _animator.PlayAnim(EAnimationsType.Idle);
            _cancelToken?.Cancel();
        }

        private void OnDestroy()
        {
            _cancelToken?.Cancel();
            _disposable?.Clear();
        }
    }
}