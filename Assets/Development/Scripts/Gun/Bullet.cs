using UnityEngine;

namespace ShooterMuliplayer
{
    [RequireComponent(typeof(BulletCollisionHandler))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _moveSpeed;

        private BulletCollisionHandler _collisionHandler;

        private void Start()
        {
            _collisionHandler = GetComponent<BulletCollisionHandler>();
            _collisionHandler.Initialize(_damage);
        }

        private void Update()
        {
            transform.Translate(Vector3.up * _moveSpeed * Time.deltaTime);
        }
    }
}
