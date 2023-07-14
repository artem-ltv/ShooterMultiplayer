using UnityEngine;

namespace ShooterMuliplayer
{
    public class BulletCollisionHandler : MonoBehaviour
    {
        private int _damage;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Bullet");
            if (collision.gameObject.TryGetComponent(out Player player))
            {
                if (player.gameObject.TryGetComponent(out PlayerHealth playerHealth))
                {
                    playerHealth.AddDamage(_damage);
                }
            }
        }

        public void SetDamage(int damage)
        {
            _damage = damage;
        }
    }
}
