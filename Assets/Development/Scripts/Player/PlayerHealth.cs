using UnityEngine;
using TMPro;

namespace ShooterMuliplayer
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int _health;

        private TMP_Text _healthText;
        private float _offsetY = 1f;

        private void Update()
        {
            if(_healthText != null)
            {
                _healthText.transform.position = new Vector3(transform.position.x, transform.position.y + _offsetY, transform.position.z);
            }
        }

        public void Initialize(TMP_Text healthText)
        {
            _healthText = healthText;
            UpdateHealthText();
        }

        public void AddDamage(int damage)
        {
            _health -= damage;
            UpdateHealthText();
            if (_health <= 0)
            {
                Die();
            }

        }

        private void UpdateHealthText()
        {
            _healthText.text = _health.ToString();
            if(_health <= 0)
            {
                _healthText.text = "0";
            }
        }

        private void Die()
        {
            //
        }
    }
}
