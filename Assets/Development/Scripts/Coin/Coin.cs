using UnityEngine;
using Photon.Pun;

namespace ShooterMuliplayer
{
    [RequireComponent(typeof(PhotonView))]
    public class Coin : MonoBehaviour
    {
        private PhotonView _photonView;

        private void Start()
        {
            _photonView = GetComponent<PhotonView>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.TryGetComponent(out Player player))
            {
                Wallet wallet = player.GetComponentInChildren<Wallet>();
                wallet.AddCoin();
                _photonView.RPC("DestroyCoin", RpcTarget.AllBuffered);
            }
        }

        [PunRPC]
        private void DestroyCoin()
        {
            gameObject.SetActive(false);
        }
    }
}
