using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Scripts.Configs.Spawn
{
    [Serializable]
    public class TypedSpawnData<TType> : SpawnData where TType : Enum
    {
        [HorizontalGroup("Main")]
        [VerticalGroup("Main/Left")]
        [HideLabel]
        
        [SerializeField] private TType _type;
        public TType Type => _type;
        
        public TypedSpawnData(TType type, Units.Enemy prefab) : base(prefab)
        {
            this._type = type;
        }
    }
}