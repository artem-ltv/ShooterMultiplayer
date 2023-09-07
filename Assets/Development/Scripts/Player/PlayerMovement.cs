using UnityEngine;

namespace ShooterMuliplayer
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        private bool _canMove = true;

        public void TryMove(Vector3 direction)
        {
            if (_canMove)
            {
                transform.Translate(direction * _moveSpeed * Time.deltaTime);
            }
        }
    }
}
