using UnityEngine;

namespace Project.Scripts.UI
{
    public class Screen : MonoBehaviour
    {
        [SerializeField] private EScreenType _screenType;

        public EScreenType ScreenType => _screenType;
    }
}