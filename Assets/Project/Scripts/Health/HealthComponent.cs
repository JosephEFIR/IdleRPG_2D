using System;
using Project.Scripts.Common;
using Project.Scripts.Configs;
using UniRx;
using UnityEngine;
using Unit = Project.Scripts.Units.Unit;

namespace Project.Scripts.Health
{
    [RequireComponent(typeof(Animator))]
    public abstract class HealthComponent : MonoBehaviour
    {
        [NonSerialized] public ReactiveProperty<float> CurrentHealth = new();
        [NonSerialized] public ReactiveProperty<float> Armor = new();
        public float MaxHealth { get; protected set; }

        private Animator _animator;
        private BaseAutoAttacker _baseAutoAttacker;

        private Units.Unit Unit;
        private UnitConfig _config;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            Unit = GetComponent<Unit>();
            _baseAutoAttacker = GetComponent<BaseAutoAttacker>();
            _config = Unit.Config;
        }

        private void Start()
        {
            CurrentHealth.Value = _config.UnitStats[EUnitStat.Health];
            MaxHealth = CurrentHealth.Value;
            Armor.Value = _config.UnitStats[EUnitStat.Armor];
        }

        public void AddHealth(float value)
        {
            CurrentHealth.Value += value;
            CurrentHealth.Value = MathF.Round(CurrentHealth.Value, 0);
            CurrentHealth.Value = Math.Clamp(CurrentHealth.Value, 1, MaxHealth);
        }

        public void GetDamage(float value)
        {
            _animator.SetTrigger("GetDamage");
            float damage = value - value * Armor.Value / 100;
            CurrentHealth.Value -= damage;
            CurrentHealth.Value = MathF.Round(CurrentHealth.Value, 0);
            
            if (CurrentHealth.Value <= 0)
            {
                _baseAutoAttacker.StopAttack();
                Die();
            }
        }

        private void OnGetDamage()
        {
            _animator.SetTrigger("Idle");
        }

        public void Die()
        {
            _animator.SetTrigger("Die");
        }

        protected abstract void OnDie();
    }
}