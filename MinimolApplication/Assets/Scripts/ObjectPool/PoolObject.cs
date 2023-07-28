using System;
using UnityEngine;

namespace MinimolGames
{
    public class PoolObject : MonoBehaviour, IPoolable<PoolObject>
    {
        private Action<PoolObject> returnToPool;

        private void OnDisable() => ReturnToPool();

        public void Initialize(Action<PoolObject> p_returnAction) => returnToPool = p_returnAction;

        public void ReturnToPool() => returnToPool?.Invoke(this);

    }
}