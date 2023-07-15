using UnityEngine;
using Photon.Pun;
using TMPro;

namespace ShooterMuliplayer
{
    [RequireComponent(typeof(PhotonView))]
    [RequireComponent(typeof(PlayerHealth))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _faceSpriteRenderer;
        [SerializeField] private Sprite _playerFace;
        [SerializeField] private Sprite _faceOfDeath;
        [SerializeField] private TMP_Text _nickname;

        private PhotonView _photonView;
        private PlayerHealth _health;
        private float _nicknameOffsetY = 0.95f;

        private void Awake()
        {
            _health = GetComponent<PlayerHealth>();
            _photonView = GetComponent<PhotonView>();
            _nickname.text = _photonView.Owner.NickName;
            if (_photonView.IsMine)
            {
                _nickname.color = Color.green;
                _faceSpriteRenderer.sprite = _playerFace;
            }
        }

        private void OnEnable()
        {
            _health.Dying += SetFaceOfDeath;
        }


        private void OnDisable()
        {
            _health.Dying -= SetFaceOfDeath;
        }
  
        private void Update()
        {
            _nickname.transform.position = new Vector3(transform.position.x, transform.position.y + _nicknameOffsetY, transform.position.z);
        }

        private void SetFaceOfDeath()
        {
            _faceSpriteRenderer.sprite = _faceOfDeath;
        }
    }
}
