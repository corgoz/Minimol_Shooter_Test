using UnityEngine;

namespace MinimolGames
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private Vector3 _rotationSpeed;
        private Transform _tranform;

        void Start()
        {
            _tranform = transform;
        }

        void Update()
        {
            _tranform.Rotate(_rotationSpeed * Time.deltaTime);
        }
    }
}
