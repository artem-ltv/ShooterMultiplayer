using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShooterMuliplayer
{
    public class PlayerInitialization : MonoBehaviour
    {
        [SerializeField] private FixedJoystick _joystick;
        [SerializeField] private Button _shotButton;
        [SerializeField] private TMP_Text _healthText;

        private GameObject _player;

        public void Initialize(GameObject player)
        {
            _player = player;
            InitializeJoystick();
            InitializeGun();
            InitializeHealthText();
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
                gun.Initialize(_shotButton);
            }
        }

        private void InitializeHealthText()
        {
            if (_player.TryGetComponent(out PlayerHealth playerHealth))
            {
                playerHealth.Initialize(_healthText);
            }
        }
    }
}
