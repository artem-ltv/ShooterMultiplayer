using UnityEngine;

namespace ShooterMuliplayer
{
    public class AntiRotation : MonoBehaviour
    {
        private void LateUpdate()
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
