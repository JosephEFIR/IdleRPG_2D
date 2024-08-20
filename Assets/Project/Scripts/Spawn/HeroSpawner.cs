using Project.Scripts.Factory;
using Project.Scripts.Units;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Spawn
{
    public class HeroSpawner : MonoBehaviour
    {
        [Inject] private UnitFactory _unitFactory;
        [SerializeField] private Player _player;

        private void Start()
        {
            _unitFactory.Create(_player, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        }
    }
}