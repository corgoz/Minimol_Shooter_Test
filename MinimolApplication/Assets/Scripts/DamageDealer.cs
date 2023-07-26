using UnityEngine;

namespace MinimolGames
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] private int _damageAmount;

        public int DamageAmount => _damageAmount;
    }
}
