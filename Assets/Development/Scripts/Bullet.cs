using UnityEngine;

namespace ShooterMuliplayer
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        private void Update()
        {
            transform.Translate(Vector3.up * _moveSpeed * Time.deltaTime);
        }
    }
}
