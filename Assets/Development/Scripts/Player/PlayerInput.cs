using UnityEngine;

namespace ShooterMuliplayer
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private Gun _gun;

        private string _horizontalText = "Horizontal";
        private string _verticalText = "Vertical";

        private void Update()
        {
            ControlMovement();
            ControlShooting();
        }

        private void ControlMovement()
        {
            float horizontal = Input.GetAxis(_horizontalText);
            float vertical = Input.GetAxis(_verticalText);

            Vector3 direction = new(horizontal, vertical, 0f);
            _movement.TryMove(direction);
        }

        private void ControlShooting()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _gun.TryShot();
            }
        }
    }
}
