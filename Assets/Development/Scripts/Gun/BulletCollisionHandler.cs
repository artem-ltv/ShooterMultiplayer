using Photon.Pun;
using UnityEngine;

namespace ShooterMuliplayer
{
    public class BulletCollisionHandler : MonoBehaviour
    {
        private int _damage;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Player player))
            {
                if (player.gameObject.TryGetComponent(out PlayerHealth playerHealth))
                {
                    playerHealth.AddDamage(_damage);
                }
            }

            PhotonNetwork.Destroy(this.gameObject);
        }

        public void Initialize(int damage)
        {
            _damage = damage;
        }
    }
}
