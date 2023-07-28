using UnityEngine;

namespace MinimolGames
{
    [CreateAssetMenu(fileName = "new DamageDealer", menuName = "DamageDealer", order = 1)]
    public class DamageDealerSettings : ScriptableObject
    {
        [SerializeField] protected int _damageAmount;

        public int DamageAmount => _damageAmount;
    }
}
