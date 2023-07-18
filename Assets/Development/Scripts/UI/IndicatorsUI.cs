using UnityEngine;
using TMPro;

namespace ShooterMuliplayer
{
    public class IndicatorsUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _health;
        [SerializeField] private TMP_Text _coins;

        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private Wallet _wallet;

        private void OnDisable()
        {
            _playerHealth.AddingDamage -= ChangeHealthValue;
            _wallet.TakingCoin -= ChangeCoinsValue;
        }

        public void Initialize(PlayerHealth playerHealth, Wallet wallet)
        {
            _playerHealth = playerHealth;
            _wallet = wallet;

            _playerHealth.AddingDamage += ChangeHealthValue;
            _wallet.TakingCoin += ChangeCoinsValue;
        }

        private void ChangeHealthValue(int health)
        {
            _health.text = $"Health: {health}";
        }

        private void ChangeCoinsValue(int coins)
        {
            _coins.text = $"Coins: {coins}";
        }
    }
}
