using Project.Configs.Weapons;
using Project.Scripts.Configs;
using Project.Scripts.Configs.Audio;
using Project.Scripts.Configs.Spawn;
using Project.Scripts.INFO;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace Project.Scripts.Editor
{
    public class ConfigsEditor: OdinMenuEditorWindow
    {
        private const string CONFIG_PATH = "Assets/Project/Configs/";

        private const string HEROES_CONFIGS_PATH = CONFIG_PATH + "Heroes";
        private const string ENEMY_CONFIGS_PATH = CONFIG_PATH + "Enemies";
        private const string ROOT_CONFIGS_PATH = CONFIG_PATH;
        private const string SPAWN_CONFIGS_PATH = CONFIG_PATH + "Spawn";
        private const string AUDIO_CONFIGS_PATH = CONFIG_PATH + "Audio";
        private const string WEAPONS_CONFIGS_PATH = CONFIG_PATH + "Weapons";
        private const string PLAYERINFO_CONFIGS_PATH = CONFIG_PATH + "PlayerInfo";

        [MenuItem("Tools/Configs Editor")]
        private static void ShowWindow()
        {
            var window = GetWindow<ConfigsEditor>();

            SetSettings(window);
        }

        private static void SetSettings(ConfigsEditor window)
        {
            window.titleContent = new GUIContent("Configs Editor");

            Vector2 size = new Vector2(630, 700);
            window.minSize = size;
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            var menuTree = new OdinMenuTree();
            
            menuTree.AddAllAssetsAtPath("Heroes", HEROES_CONFIGS_PATH, typeof(PlayerConfig));
            menuTree.AddAllAssetsAtPath("Enemies", ENEMY_CONFIGS_PATH, typeof(EnemyConfig));
            menuTree.AddAllAssetsAtPath("Root", ROOT_CONFIGS_PATH, typeof(RootConfig));
            menuTree.AddAllAssetsAtPath("Spawn", SPAWN_CONFIGS_PATH, typeof(EnemiesSpawnConfig));
            menuTree.AddAllAssetsAtPath("Audio", AUDIO_CONFIGS_PATH, typeof(AudioConfig));
            menuTree.AddAllAssetsAtPath("PlayerInfo", PLAYERINFO_CONFIGS_PATH, typeof(PlayerInfoData));
            return menuTree;
        }
    }
}