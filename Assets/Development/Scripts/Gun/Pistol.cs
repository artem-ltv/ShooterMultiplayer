using System.Collections;
using UnityEngine;

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
            Bullet newBullet = Instantiate(Bullet, ShootPoint.position, transform.rotation);

            newBullet.Init(Damage);
            newBullet.transform.SetParent(null);
        }
    }
}
