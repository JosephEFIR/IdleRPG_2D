using Project.Scripts.Health;
using Project.Scripts.Units;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI
{
    public class RegenButton : MonoBehaviour
    {
        private Button _button;
        private Player _player;
        private HealthComponent _healthComponent;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
            _player = FindObjectOfType<Player>();
            _healthComponent = _player.GetComponent<HealthComponent>();
        }

        private void Start()
        {
            _button.onClick.AddListener(AddHealth);
        }

        private void AddHealth()
        {
            _healthComponent.AddHealth(_healthComponent.MaxHealth);
        }
    }
}