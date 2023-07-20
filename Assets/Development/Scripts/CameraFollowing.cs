using UnityEngine;

namespace ShooterMuliplayer
{
    public class CameraFollowing : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        private Transform _player;
        private Vector3 _targetPosition;

        private float _offsetZ = -1f;

        public void Initialize(Transform player)
        {
            _player = player;
        }

        private void Update()
        {
            if(_player != null)
            { 
                _targetPosition = new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z + _offsetZ);
                transform.position = Vector3.Lerp(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
            }
        }
    }
}
