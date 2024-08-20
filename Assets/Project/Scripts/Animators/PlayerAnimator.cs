using Project.Scripts.Weapons;
using UniRx;
using UnityEngine;

namespace Project.Scripts
{
    public class PlayerAnimator : BaseAnimator
    {
        private string Attack = "Attack";
        private string Idle= "Idle";
        private string GetDamage = "GetDamage";
        private string Die = "Die";

        [SerializeField] private Animator _animator;
        
        private WeaponSwitcher _weaponSwitcher;
        private Weapon _weapon;

        private CompositeDisposable _disposable = new();
        
        private void Awake()
        {
            _weaponSwitcher = GetComponentInChildren<WeaponSwitcher>();
        }
        private void Start()
        {
            _weaponSwitcher.CurrentWeapon.Subscribe(v =>
            {
                _weapon = v;
            }).AddTo(_disposable);
        }
        
        public override void PlayAnim(EAnimationsType animType)
        {
            switch (animType)
            {
                case EAnimationsType.Attack:
                    _animator.SetTrigger(Attack + _weapon.WeaponType) ;
                    break;
                case EAnimationsType.Idle:
                    _animator.SetTrigger(Idle + _weapon.WeaponType);
                    break;
                case EAnimationsType.GetDamage:
                    _animator.SetTrigger(GetDamage);
                    break;
                case EAnimationsType.Die:
                    _animator.SetTrigger(Die);
                    break;
                default:
                    Debug.LogError("Animation error");
                    break;
            }
        }

        private void OnDestroy()
        {
            _disposable?.Clear();
        }
    }
}