using Photon.Pun;
using System.Collections;
using UnityEngine;

namespace ShooterMuliplayer
{
    public abstract class Gun : MonoBehaviour
    {
        [SerializeField] private PhotonView _photonView;
        [SerializeField] protected Transform ShootPoint;
        [SerializeField] protected Bullet Bullet;
        [SerializeField] protected int Damage;
        [SerializeField] protected float ReloadingTime;
        [SerializeField] protected int MaxCountPatrons;

        protected int CountPatrons;
        protected bool CanShoot;

        private float _offsetZ = -90f;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            CountPatrons = MaxCountPatrons;

            if(CountPatrons > 0)
            {
                SetShootAbility(true);
            }
        }
        
        private void Update()
        {
            Vector3 diffrence = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotateZ = Mathf.Atan2(diffrence.y, diffrence.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + _offsetZ);
        }

        public virtual void TryShot()
        {
            if (!_photonView.IsMine)
            {
                return;
            }

            if (CanShoot)
            {
                Shot();
                CountPatrons--;

                if(CountPatrons <= 0)
                {
                    StartCoroutine(Reload(ReloadingTime));
                }
            }
        }
        
        public void SetShootAbility(bool isShootAbility)
        {
            CanShoot = isShootAbility;
        }

        protected abstract void Shot();

        protected abstract IEnumerator Reload(float reloadingTime);
    }
}
