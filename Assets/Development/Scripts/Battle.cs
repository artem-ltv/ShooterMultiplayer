using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;

namespace ShooterMuliplayer
{
    public class Battle : MonoBehaviour
    {
        public UnityAction StartingBattle;

        private int _minNumberOfPlayers = 2;

        public void TryStartBattle()
        {
            if(PhotonNetwork.CurrentRoom.PlayerCount >= _minNumberOfPlayers)
            {
                StartingBattle?.Invoke();
            }
        }
    }
}
