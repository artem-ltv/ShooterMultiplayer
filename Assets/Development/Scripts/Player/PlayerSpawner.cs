using UnityEngine;
using Photon.Pun;

namespace ShooterMuliplayer
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private PlayerInitialization _inititalization;

        private void Start()
        {
            DefineSpawnPoint();
        }

        private void DefineSpawnPoint()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                Spawn(_player, _spawnPoints[0].position);
            }
            else
            {
                Spawn(_player, _spawnPoints[1].position);
            }
        }

        private void Spawn(Player player, Vector3 spawnPoint)
        {
            GameObject playerObject = PhotonNetwork.Instantiate(player.name, spawnPoint, Quaternion.identity);

            Player newPlayer = playerObject.GetComponent<Player>();
            _inititalization.Init(newPlayer);
        }
    }
}
