using UnityEngine;

namespace Project.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class EnemyAnimator : BaseAnimator
    {
        private string Attack = "Attack";
        private string Idle= "Idle";
        private string GetDamage = "GetDamage";
        private string Die = "Die";

        [SerializeField] private Animator _animator;

        public override void PlayAnim(EAnimationsType animType)
        {
            switch (animType)
            {
                case EAnimationsType.Attack:
                    _animator.SetTrigger(Attack );
                    break;
                case EAnimationsType.Idle:
                    _animator.SetTrigger(Idle);
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
    }
}