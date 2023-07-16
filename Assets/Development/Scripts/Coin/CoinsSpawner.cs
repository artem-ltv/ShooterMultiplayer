using UnityEngine;
using Photon.Pun;

namespace ShooterMuliplayer
{
    public class CoinsSpawner : MonoBehaviour
    {
        [SerializeField] private Coin _coin;
        [SerializeField] private int _numberOfCoins;
        [SerializeField] private float _minX, _maxX, _minY, _maxY;

        private void Start()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                for (int i = 0; i<_numberOfCoins; i++)
                {
                    Vector2 randomPoint = new Vector2(Random.Range(_minX, _maxX), Random.Range(_minY, _maxY));
                    PhotonNetwork.Instantiate(_coin.gameObject.name, randomPoint, Quaternion.identity);
                }
            }
        }
    }
}
