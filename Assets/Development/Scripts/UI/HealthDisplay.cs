using UnityEngine;
using TMPro;

namespace ShooterMuliplayer
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _healthDisplay;
        
        private Player _player;

        public void Init(Player player)
        {
            _player = player;
            _player.HealthChanged += OnHealthChanged;

            _healthDisplay.text = _player.Health.ToString();
        }

        private void OnDisable()
        {
            _player.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(int health)
        {
            _healthDisplay.text = health.ToString();
        }
    }
}
