using UnityEngine;
using TMPro;
using UnityEngine.Events;
using Photon.Pun;

namespace ShooterMuliplayer
{
    [RequireComponent(typeof(PhotonView))]
    public class PlayerHealth : MonoBehaviour
    {
        public UnityAction Dying;
        public UnityAction<int> AddingDamage;

        [SerializeField] private int _health;
        [SerializeField] private TMP_Text _healthText;

        private PhotonView _photonView;
        private float _healthTextOffsetY = 1.25f;

        private void Start()
        {
            _photonView = GetComponent<PhotonView>();
            //if (_photonView.IsMine)
            //{
            //    _healthText.enabled = false;
            //}
        }

        private void Update()
        {
            _healthText.transform.position = new Vector3(transform.position.x, transform.position.y + _healthTextOffsetY, transform.position.z);
        }

        public void AddDamage(int damage)
        {
            _health -= damage;
            Debug.Log($"I have damage, Health: {_health}");
            UpdateHealthText();
            AddingDamage?.Invoke(_health);
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
            Dying?.Invoke();
        }
    }
}
