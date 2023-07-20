using UnityEngine;
using Photon.Pun;

namespace ShooterMuliplayer
{
    [RequireComponent(typeof(PhotonView))]
    public class PlayersSpawner : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private float _minX, _maxX, _minY, _maxY;
        [SerializeField] private Battle _battle;
        [SerializeField] private PlayerInitialization _playerInitialization;

        private PhotonView _photonView;

        private void Start()
        {
            _photonView = GetComponent<PhotonView>();

            Vector2 randomSpawnPoint = new Vector2(Random.Range(_minX, _maxX), Random.Range(_minY, _maxY));
            GameObject newPlayer = PhotonNetwork.Instantiate(_player.gameObject.name, randomSpawnPoint, Quaternion.identity);
            _playerInitialization.Initialize(newPlayer);
            _photonView.RPC("TryStartBattle", RpcTarget.AllBuffered);
        }

        [PunRPC]
        private void TryStartBattle()
        {
            _battle.TryStartBattle();
        }
    }
}
