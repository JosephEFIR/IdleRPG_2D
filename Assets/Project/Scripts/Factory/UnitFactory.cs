using Project.Scripts.Units;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Factory
{
    public class UnitFactory
    {
        [Inject] private DiContainer _container;

        public Unit Create(Unit gameObject, Vector3 pos, Quaternion rot, Transform parent)
        {
            return _container.InstantiatePrefabForComponent<Unit>(gameObject, pos, rot, parent); 
        }

        public Units.Enemy CreateEnemy(Units.Enemy gameObject, Vector3 pos, Quaternion rot, Transform parent)
        {
            return _container.InstantiatePrefabForComponent<Units.Enemy>(gameObject, pos, rot, parent);
        }
    }
}