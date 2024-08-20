using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Project.Scripts.UI
{
    public enum EScreenType
    {
        None,
        Game,
        Victory,
        Failed
    }
    
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Screen _startUIScreen;

        private Dictionary<EScreenType, Screen> _screens = new();

        private void Awake()
        {
            List<Screen> screens = GetComponentsInChildren<Screen>().ToList(); //TODO костыль!
            foreach (var screen in screens)
            {
                _screens.Add(screen.ScreenType, screen);
            }
        }

        private async void Start()
        {
            await UniTask.Delay(1000);
            _startUIScreen.gameObject.SetActive(true);
        }

        public void SetScreen(EScreenType type)
        {
            _screens[type].gameObject.SetActive(true);
        }
    }
}