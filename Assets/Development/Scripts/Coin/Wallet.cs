using UnityEngine;
using UnityEngine.Events;

namespace ShooterMuliplayer
{
    public class Wallet : MonoBehaviour
    {
        public UnityAction<int> TakingCoin;

        public int _coins = 0;

        public void AddCoin()
        {
            _coins++;
            TakingCoin?.Invoke(_coins);
        }
    }
}
