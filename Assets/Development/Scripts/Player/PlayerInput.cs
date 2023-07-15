using UnityEngine;
using Photon.Pun;

namespace ShooterMuliplayer
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerInput : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private FixedJoystick _fixedJoystick;
        private PhotonView _photonView;

        private void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _photonView = GetComponent<PhotonView>();
        }

        private void FixedUpdate()
        {
            if (_photonView.IsMine) 
            {
                Vector3 direction = (Vector3.up * _fixedJoystick.Vertical + Vector3.right * _fixedJoystick.Horizontal);
                _playerMovement.Move(direction);

                if (_fixedJoystick.Horizontal != 0 || _fixedJoystick.Vertical != 0)
                {
                    _playerMovement.Rotate(direction);
                }
            }
        }

        public void Initialize(FixedJoystick joystick)
        {
            _fixedJoystick = joystick;
        }
    }
}
