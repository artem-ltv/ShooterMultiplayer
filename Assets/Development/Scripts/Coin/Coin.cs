using UnityEngine;
using Photon.Pun;

namespace ShooterMuliplayer
{
    public class Coin : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.TryGetComponent(out Player player))
            {
                Wallet wallet = player.GetComponentInChildren<Wallet>();
                wallet.AddCoin();
                PhotonNetwork.Destroy(this.gameObject);
            }
        }
    }
}
