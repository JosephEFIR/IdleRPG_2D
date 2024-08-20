using UnityEngine;

namespace Project.Scripts
{
    public abstract class BaseAnimator : MonoBehaviour
    {
        public abstract void PlayAnim(EAnimationsType animationsType);
    }
}