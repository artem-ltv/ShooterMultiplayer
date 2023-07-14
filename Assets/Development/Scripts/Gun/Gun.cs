using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

namespace ShooterMuliplayer
{
    [RequireComponent(typeof(PhotonView))]
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _shotPoint;
        [SerializeField] private Button _shot;

        private PhotonView _photonView;

        private void Start()
        {
            _photonView = GetComponent<PhotonView>();
        }

        private void OnDisable()
        {
            _shot.onClick.RemoveListener(Shot);
        }

        public void Initialize(Button shot)
        {
            _shot = shot;
            _shot.onClick.AddListener(Shot);
        }

        private void Shot()
        {
            if (_photonView.IsMine)
            {
                PhotonNetwork.Instantiate(_bullet.gameObject.name, _shotPoint.position, transform.rotation);
            }
        }
    }
}
