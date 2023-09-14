using System.Collections;
using UnityEngine;
using Photon.Pun;

namespace ShooterMuliplayer
{
    public class Pistol : Gun
    {
        protected override IEnumerator Reload(float reloadingTime)
        {
            SetShootAbility(false);

            yield return new WaitForSeconds(reloadingTime);
            
            CountPatrons = MaxCountPatrons;
            SetShootAbility(true);
        }

        protected override void Shot()
        {
            GameObject newBulletObject = PhotonNetwork.Instantiate(Bullet.name, ShootPoint.position, transform.rotation);

            Bullet newBullet = newBulletObject.GetComponent<Bullet>();
            newBullet.Init(Damage);
            newBullet.transform.SetParent(null);
        }
    }
}
