using Project.Scripts.Health;
using UnityEngine;

namespace Project.Scripts.Units
{
    [RequireComponent(typeof(EnemyHealth))]
    public class Enemy : Unit
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}