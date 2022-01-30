using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ClawBrawl
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        public bool doFacing = true;

        private Vector2 inputDir;

        private void Update()
        {
            HandleMove();
            if (doFacing) HandleRotate();
        }

        public void MovePlayer(InputAction.CallbackContext context)
        {
            if (context.started) return;

            inputDir = context.ReadValue<Vector2>();

        }

        private void HandleMove()
        {
            Vector3 moveDir = Vector3.forward * inputDir.y + Vector3.right * inputDir.x;
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }

        private void HandleRotate()
        {
            if (inputDir == Vector2.zero) return;

            Vector3 lookDir = new Vector3(inputDir.x, 0, inputDir.y);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDir), 0.2f);
        }
    }
}
