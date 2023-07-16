using Photon.Pun;
using UnityEngine.SceneManagement;

namespace ShooterMuliplayer
{
    public class ServerConnector : MonoBehaviourPunCallbacks
    {
        private string _gameVersion = "1";

        private void Start()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.GameVersion = _gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            SceneManager.LoadScene(1);
        }
    }
}
