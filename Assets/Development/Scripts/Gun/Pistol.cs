using UnityEngine;

namespace ShooterMuliplayer
{
    public class Pistol : Gun
    {
        protected override void Reload(float reloadingTime)
        {
            throw new System.NotImplementedException();
        }

        public override void Shot()
        {
            Debug.Log("Shot");
        }
    }
}
