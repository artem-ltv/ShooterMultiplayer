using UnityEngine;
using Photon.Pun;

namespace ShooterMuliplayer
{
    [RequireComponent(typeof(PlayerInitialization))]
    public class PlayersSpawner : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private float _minX, _maxX, _minY, _maxY;

        private PlayerInitialization _playerInitialization;

        private void Start()
        {
            _playerInitialization = GetComponent<PlayerInitialization>();
            Spawn();
        }

        private void Spawn()
        {
            Vector2 randomSpawnPoint = new Vector2(Random.Range(_minX, _maxX), Random.Range(_minY, _maxY));
            GameObject newPlayer = PhotonNetwork.Instantiate(_player.gameObject.name, randomSpawnPoint, Quaternion.identity);
            _playerInitialization.Initialize(newPlayer);
        }
    }
}
