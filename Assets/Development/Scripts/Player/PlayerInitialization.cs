using UnityEngine;
using UnityEngine.UI;

namespace ShooterMuliplayer
{
    public class PlayerInitialization : MonoBehaviour
    {
        [SerializeField] private FixedJoystick _joystick;
        [SerializeField] private Button _shotButton;
        [SerializeField] private Battle _battle;
        [SerializeField] private IndicatorsUI _indicators;

        private GameObject _player;

        public void Initialize(GameObject player)
        {
            _player = player;
            InitializeJoystick();
            InitializeGun();
            InitializeMove();
            InitializeIndicators();
        }

        private void InitializeJoystick()
        {
            if (_player.TryGetComponent(out PlayerInput playerInput))
            {
                playerInput.Initialize(_joystick);
            }
        }

        private void InitializeGun()
        {
            Gun gun = _player.GetComponentInChildren<Gun>();
            if (gun != null)
            {
                gun.Initialize(_shotButton, _battle);
            }
        }

        private void InitializeMove()
        {
            if (_player.TryGetComponent(out PlayerMovement playerMovement))
            {
                playerMovement.Initialize(_battle);
            }
        }

        private void InitializeIndicators()
        {
            Wallet wallet = _player.GetComponentInChildren<Wallet>();
            if(_player.TryGetComponent(out PlayerHealth _playerHealth) && wallet != null)
            {
                _indicators.Initialize(_playerHealth, wallet);
            }
        }
    }
}
