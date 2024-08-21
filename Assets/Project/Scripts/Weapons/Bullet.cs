using UnityEngine;

namespace Project.Scripts.Weapons
{
    public class Bullet : MonoBehaviour
    {
        private BulletSpawnPoint _bulletSpawnPoint;
        
        private void Awake()
        {
            _bulletSpawnPoint = GetComponentInParent<BulletSpawnPoint>();
            gameObject.SetActive(false);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                gameObject.transform.position = _bulletSpawnPoint.transform.position; //TODO костыль
                gameObject.SetActive(false);
            }
        }
    }
}