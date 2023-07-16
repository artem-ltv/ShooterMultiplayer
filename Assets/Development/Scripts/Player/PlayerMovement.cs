using UnityEngine;

namespace ShooterMuliplayer
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        private Rigidbody2D _rigidbody;
        private bool _canMove;
        private Battle _battle;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnDisable()
        {
            _battle.StartingBattle -= AllowMove;
        }

        public void Initialize(Battle battle)
        {
            _battle = battle;
            _battle.StartingBattle += AllowMove;
        }

        public void Move(Vector3 direction)
        {
            if (_canMove)
            {
                _rigidbody.velocity = direction * _moveSpeed;
            }
        }

        public void Rotate(Vector3 direction)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }

        private void AllowMove()
        {
            _canMove = true;
        }
    }
}
