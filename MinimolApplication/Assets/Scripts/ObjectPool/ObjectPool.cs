using System.Collections.Generic;
using UnityEngine;
using System;

namespace MinimolGames
{
    public class ObjectPool<T> : IPool<T> where T : MonoBehaviour, IPoolable<T>
    {
        private Action<T> _pullObject;
        private Action<T> _pushObject;
        private Stack<T> _pooledObjects = new Stack<T>();
        private GameObject _prefab;
        
        public int PooledCount => _pooledObjects.Count;

        public ObjectPool(GameObject p_pooledObject, int p_numToSpawn = 0)
        {
            _prefab = p_pooledObject;
            Spawn(p_numToSpawn);
        }

        public ObjectPool(GameObject p_pooledObject, Action<T> p_pullObject, Action<T> p_pushObject, int p_numToSpawn = 0)
        {
            _prefab = p_pooledObject;
            _pullObject = p_pullObject;
            _pushObject = p_pushObject;
            Spawn(p_numToSpawn);
        }

        public T Pull()
        {
            T t;
            if (PooledCount > 0)
                t = _pooledObjects.Pop();
            else
                t = GameObject.Instantiate(_prefab).GetComponent<T>();

            t.gameObject.SetActive(true);
            t.Initialize(Push);

            _pullObject?.Invoke(t);

            return t;
        }

        public T Pull(Vector3 p_position)
        {
            T t = Pull();
            t.transform.position = p_position;
            return t;
        }

        public T Pull(Vector3 p_position, Quaternion p_rotation)
        {
            T t = Pull();
            t.transform.position = p_position;
            t.transform.rotation = p_rotation;
            return t;
        }

        public GameObject PullGameObject() => Pull().gameObject;

        public GameObject PullGameObject(Vector3 p_position)
        {
            GameObject go = Pull().gameObject;
            go.transform.position = p_position;
            return go;
        }

        public GameObject PullGameObject(Vector3 p_position, Quaternion p_rotation)
        {
            GameObject go = Pull().gameObject;
            go.transform.position = p_position;
            go.transform.rotation = p_rotation;
            return go;
        }

        public void Push(T t)
        {
            _pooledObjects.Push(t);

            _pushObject?.Invoke(t);

            t.gameObject.SetActive(false);
        }

        private void Spawn(int p_number)
        {
            T t;

            for (int i = 0; i < p_number; i++)
            {
                t = GameObject.Instantiate(_prefab).GetComponent<T>();
                _pooledObjects.Push(t);
                t.gameObject.SetActive(false);
            }
        }
    }
}