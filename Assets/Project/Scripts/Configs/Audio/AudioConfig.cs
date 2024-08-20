using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Scripts.Configs.Audio
{
    [CreateAssetMenu(fileName = "BattleAudioConfig",  menuName = "Configs/Audio")]
    public class AudioConfig : SerializedScriptableObject
    {
        [SerializeField] private Dictionary<EBattleAudio, AudioClip> _battleAudioClips = new ();
        public Dictionary<EBattleAudio, AudioClip> BattleAudioClips => _battleAudioClips;
    }

    public enum EBattleAudio
    {
        None,
        SwordSwing,
        SwordHit,
        GunFire, //TODO а?
        BulletHit,
    }
}