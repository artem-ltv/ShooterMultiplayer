using Photon.Pun;
using UnityEngine.SceneManagement;

namespace ShooterMuliplayer
{
    public class ServerConnector : MonoBehaviourPunCallbacks
    {
        private void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            SceneManager.LoadScene(1);
        }
    }
}
