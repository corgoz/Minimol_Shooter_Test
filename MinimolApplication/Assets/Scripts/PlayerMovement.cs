using UnityEngine;

namespace MinimolGames
{
    public class PlayerMovement : CharacterMovement
    {
        private void Update()
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

        private void Move(Vector3 input)
        {
            _navMeshAgent.Move(_characterSettings.MoveSpeed * Time.deltaTime * input.normalized);
           // transform.Translate(_characterSettings.MoveSpeed * Time.deltaTime * input.normalized, Space.World);
        }

        private void Rotate(RaycastHit hit)
        {
            Vector3 direction = hit.point - transform.position;
            direction.y = 0f; // To prevent tilting up or down

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            float step = _characterSettings.RotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, step);
        }
    }
}