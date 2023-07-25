using System;
using UnityEngine;

namespace MinimolGames
{
    public class PlayerController : MonoBehaviour
    {
        public Action Death;

        [SerializeField] float _moveSpeed = 5f;
        [SerializeField] float _rotationSpeed = 5f;

        void Update()
        {
            if (!GameManager.instance.IsPlaying) return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
                Rotate(hit);

            Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (input == Vector3.zero) return;
            Move(input);
        }

        void Move(Vector3 input)
        {
            transform.Translate(_moveSpeed * Time.deltaTime * input, Space.World);
        }

        void Rotate(RaycastHit hit)
        {
            Vector3 direction = hit.point - transform.position;
            direction.y = 0f; // To prevent tilting up or down

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}
