using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

namespace ShooterMuliplayer
{
    public class LobbyMenu : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_InputField _createRoomInput;
        [SerializeField] private TMP_InputField _joinRoomInput;
        [SerializeField] private int _maxPlayersInRoom;

        public void CreateRoom()
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = _maxPlayersInRoom;
            PhotonNetwork.CreateRoom(_createRoomInput.text, roomOptions);
        }

        public void JoinRoom()
        {
            PhotonNetwork.JoinRoom(_joinRoomInput.text);
        }

        public override void OnJoinedRoom()
        {
            PhotonNetwork.LoadLevel(2);
        }

        public void SetNickname(string nickname)
        {
            PhotonNetwork.NickName = nickname;
            Debug.Log(nickname);
        }
    }
}
