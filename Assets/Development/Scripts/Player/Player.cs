using UnityEngine;
using UnityEngine.Events;

namespace ShooterMuliplayer
{
    public class Player : MonoBehaviour
    {
        public UnityAction Dying;

        [SerializeField] private int _health;

        public void TryAddDamage(int damage)
        {
            if(damage > 0)
            {
                _health -= damage;

                if(_health <= 0)
                {
                    Die();
                }
            }
        }

        private void Die()
        {
            Dying?.Invoke();
        }
    }
}
