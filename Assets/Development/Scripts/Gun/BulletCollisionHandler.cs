using Photon.Pun;
using UnityEngine;

namespace ShooterMuliplayer
{
    [RequireComponent(typeof(PhotonView))]
    public class BulletCollisionHandler : MonoBehaviour
    {
        private PhotonView _photonView;
        private int _damage;
        private PlayerHealth _health;

        private void Start()
        {
            _photonView = GetComponent<PhotonView>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Player player))
            {
                if (player.gameObject.TryGetComponent(out PlayerHealth playerHealth))
                {
                    playerHealth.AddDamage(_damage);
                }
            }

            _photonView.RPC("DestroyBullet", RpcTarget.AllBuffered);
        }

        public void Initialize(int damage)
        {
            _damage = damage;
        }

        [PunRPC]
        private void DestroyBullet()
        {
            gameObject.SetActive(false);
        }
    }
}
