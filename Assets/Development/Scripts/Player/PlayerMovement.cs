using UnityEngine;

namespace ShooterMuliplayer
{
    public class PlayerMovement : MonoBehaviour
    {
        public bool CanMove => _canMove;

        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;

        private bool _canMove = true;

        public void Move(Vector3 direction)
        {
            transform.Translate(direction * _moveSpeed * Time.deltaTime);
        }
    }
}
