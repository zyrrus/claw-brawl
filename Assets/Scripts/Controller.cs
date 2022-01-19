using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClawBrawl
{
    [RequireComponent(typeof(Rigidbody))]
    public class Controller : MonoBehaviour
    {
        // Components
        private Rigidbody rb;

        // Movement
        private Vector3 inputDir;
        private bool isMoving = false;
        [SerializeField] private float moveSpeed;


        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            SetInputDir();
        }

        private void FixedUpdate()
        {
            if (isMoving)
            {
                rb.AddForce(inputDir * moveSpeed);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(inputDir), 15 * Time.deltaTime);
            }
        }

        private void SetInputDir()
        {
            // The z-axis will act as the 'y-axis' from the camera's pov

            float zInput = Input.GetAxis("Vertical");
            float xInput = Input.GetAxis("Horizontal");

            if (xInput == 0 && zInput == 0) isMoving = false;
            else isMoving = true;

            inputDir = new Vector3(xInput, 0, zInput);
            inputDir.Normalize();
        }
    }
}
