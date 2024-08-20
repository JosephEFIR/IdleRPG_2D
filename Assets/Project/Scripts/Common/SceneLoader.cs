using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Common
{
    public enum ESceneType
    {
        Game,
        Menu
    }
    
    public static class SceneLoader
    {
        public static void LoadScene(ESceneType sceneType)
        {
            switch (sceneType)
            {
                case ESceneType.Menu:
                    SceneManager.LoadScene(0);
                    break;
                case ESceneType.Game:
                    SceneManager.LoadScene(1);
                    break;
                default:
                    Debug.LogError("Scene not found");
                    SceneManager.LoadScene(0);
                    break;
            }
        }
    }
}