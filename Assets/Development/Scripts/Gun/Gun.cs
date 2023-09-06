using UnityEngine;

namespace ShooterMuliplayer
{
    public abstract class Gun : MonoBehaviour
    {
        public bool CanShoot => _canShoot;

        [SerializeField] protected float ReloadingTime;

        private Camera _camera;

        private float _offsetZ = -90f;
        private bool _canShoot = true;

        private void Start() => _camera = Camera.main;
        
        private void Update()
        {
            Vector3 diffrence = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotateZ = Mathf.Atan2(diffrence.y, diffrence.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + _offsetZ);
        }

        public abstract void Shot();

        protected abstract void Reload(float reloadingTime);
    }
}
