using UnityEngine;

namespace MinimolGames
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] protected DamageDealerSettings _settings;

        public int DamageAmount => _settings.DamageAmount;
    }
}
