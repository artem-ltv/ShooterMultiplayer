using UnityEngine;

namespace ShooterMuliplayer
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        private int _damage;

        private void Update()
        {
            transform.Translate(Vector3.up * _moveSpeed * Time.deltaTime);
        }

        public void Init(int damage)
        {
            _damage = damage;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.TryGetComponent(out Player player))
            {
                player.TryAddDamage(_damage);
            }
        }
    }
}
