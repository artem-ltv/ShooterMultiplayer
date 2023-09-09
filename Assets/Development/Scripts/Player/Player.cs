using UnityEngine;
using UnityEngine.Events;

namespace ShooterMuliplayer
{
    public class Player : MonoBehaviour
    {
        public UnityAction Dying;
        public UnityAction<int> HealthChanged;

        public int Health => _health;

        [SerializeField] private int _health;

        public void TryAddDamage(int damage)
        {
            if(damage > 0)
            {
                _health -= damage;

                HealthChanged?.Invoke(_health);

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
