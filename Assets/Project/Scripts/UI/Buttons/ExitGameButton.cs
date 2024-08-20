using System;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI
{
    public class ExitGameButton : MonoBehaviour
    {
        private Button _button;
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(Exit);
        }

        private void Exit()
        {
            Debug.LogError("Это было ошибкой");
            //Не выходи : ( 
            Application.Quit();
        }

    }
}