using UnityEngine;

namespace ShooterMuliplayer
{
    public class PlayerInitialization : MonoBehaviour
    {
        [SerializeField] private HealthDisplay _healthDisplay;

        private Player _player;

        public void Init(Player player)
        {
            _player = player;

            InitializeComponents();
        }

        private void InitializeComponents()
        {
            _healthDisplay.Init(_player);
        }
    }
}
