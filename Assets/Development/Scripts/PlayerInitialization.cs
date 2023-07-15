using UnityEngine;
using UnityEngine.UI;

namespace ShooterMuliplayer
{
    public class PlayerInitialization : MonoBehaviour
    {
        [SerializeField] private FixedJoystick _joystick;
        [SerializeField] private Button _shotButton;

        private GameObject _player;

        public void Initialize(GameObject player)
        {
            _player = player;
            InitializeJoystick();
            InitializeShotButton();
        }

        private void InitializeJoystick()
        {
            if (_player.TryGetComponent(out PlayerInput playerInput))
            {
                playerInput.Initialize(_joystick);
            }
        }

        private void InitializeShotButton()
        {
            Gun gun = _player.GetComponentInChildren<Gun>();
            if (gun != null)
            {
                gun.Initialize(_shotButton);
            }
        }
    }
}
