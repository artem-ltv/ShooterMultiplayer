using UnityEngine;
using UnityEngine.UI;

namespace ShooterMuliplayer
{
    public class PlayerInitialization : MonoBehaviour
    {
        [SerializeField] private FixedJoystick _joystick;
        [SerializeField] private Button _shotButton;

        public void InitializePlayerInput(GameObject player)
        {
            if (player.TryGetComponent(out PlayerInput playerInput))
            {
                playerInput.Initialize(_joystick);
            }
        }

        public void InitializePlayerGun(GameObject player)
        {
            Gun gun = player.GetComponentInChildren<Gun>();
            if (gun != null)
            {
                gun.Initialize(_shotButton);
            }
        }
    }
}
