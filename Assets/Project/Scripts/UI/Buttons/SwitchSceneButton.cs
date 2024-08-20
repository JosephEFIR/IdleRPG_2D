using System;
using Project.Scripts.Common;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Project.Scripts.UI
{
    public class SwitchSceneButton : MonoBehaviour
    {
        private Button _button;
        [LabelText("След экран")]
        [SerializeField] private ESceneType _sceneType;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(SceneLoad);
        }

        private void SceneLoad()
        {
            SceneLoader.LoadScene(_sceneType);
            int idCurrentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.UnloadScene(idCurrentScene);
        }
    }
}