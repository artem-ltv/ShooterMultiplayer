using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
using Photon.Realtime;

namespace ShooterMuliplayer
{
    public class Lobby : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_InputField _roomNameForCreate;
        [SerializeField] private TMP_InputField _roomNameForJoin;
        [SerializeField] private Button _createRoom;
        [SerializeField] private Button _joinRoom;

        private int _maxPlayersInRoom = 2;

        private void Start()
        {
            _createRoom.Add(CreateRoom);
            _joinRoom.Add(JoinRoom);
        }

        private void CreateRoom()
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = _maxPlayersInRoom;
            PhotonNetwork.CreateRoom(_roomNameForCreate.text, roomOptions);
        }

        private void JoinRoom()
        {
            PhotonNetwork.JoinRoom(_roomNameForJoin.text);
        }

        public override void OnJoinedRoom()
        {
            PhotonNetwork.LoadLevel(2);
        }
    }
}
