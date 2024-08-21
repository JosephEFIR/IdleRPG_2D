using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
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
    
    public class UIManager : SerializedMonoBehaviour
    {
        [SerializeField] private EScreenType _startUIScreen;
        
        [SerializeField] private Dictionary<EScreenType, Screen> _screens = new();
        
        private async void Start()
        {
            await UniTask.Delay(1000);
            SetScreen(_startUIScreen, false);
        }

        public void SetScreen(EScreenType type , bool hideCurrentScreen = true)
        {
            _screens[type].gameObject.SetActive(true);
        }
    }
}