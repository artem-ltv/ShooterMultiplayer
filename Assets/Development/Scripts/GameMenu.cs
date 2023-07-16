using Photon.Pun;
using UnityEngine.SceneManagement;

namespace ShooterMuliplayer
{
    public class GameMenu : MonoBehaviourPunCallbacks
    {
        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(1);
        }
    }
}
