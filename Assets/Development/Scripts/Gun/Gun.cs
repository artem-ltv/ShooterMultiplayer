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
        private bool _canShoot;
        private Battle _battle;

        private void Start()
        {
            _photonView = GetComponent<PhotonView>();
        }

        private void OnDisable()
        {
            _shot.onClick.RemoveListener(Shot);
            _battle.StartingBattle -= AllowShoot;
        }

        public void Initialize(Button shot, Battle battle)
        {
            _shot = shot;
            _battle = battle;
            _shot.onClick.AddListener(Shot);
            _battle.StartingBattle += AllowShoot;
        }

        private void Shot()
        {
            if (_canShoot)
            {
                if (_photonView.IsMine)
                {
                    PhotonNetwork.Instantiate(_bullet.gameObject.name, _shotPoint.position, transform.rotation);
                }
            }
        }

        private void AllowShoot()
        {
            _canShoot = true;
        }
    }
}
