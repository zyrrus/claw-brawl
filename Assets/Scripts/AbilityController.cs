using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClawBrawl
{
    public class AbilityController : MonoBehaviour
    {
        private Rigidbody rb;
        private PlayerMovement player;

        [Header("Dash")]
        [SerializeField] private bool canDash = true;
        [SerializeField] private float dashStrength;
        [SerializeField] private float dashCooldown;
        private float dashTimer;

        [Header("Throw")]
        [SerializeField] private bool canThrow = true;
        [SerializeField] private float throwStrength;
        [SerializeField] private float throwCooldown;
        [SerializeField] private float throwTimer;

        [Header("Spin")]
        [SerializeField] private float spinSpeed;
        [SerializeField] private float spinDuration;
        [SerializeField] private float spinCooldown;
        private float spinTimer;
        private bool canSpin = true;
        private bool isSpinning;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            player = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            /// === Dash ==================================================

            // Update timer
            if (dashTimer >= 0)
                dashTimer -= Time.deltaTime;

            /// === Throw =================================================

            /// === Spin ==================================================

            // Update timer
            if (spinTimer >= -spinCooldown)
                spinTimer -= Time.deltaTime;

            // Stop spin
            if (spinTimer <= 0)
            {
                isSpinning = false;
                player.doFacing = true;
            }

            // Perform spin
            if (isSpinning)
                transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
        }

        public void OnDash()
        {
            if (!canDash || dashTimer > 0) return;

            rb.AddForce(transform.forward * dashStrength, ForceMode.Impulse);
            dashTimer = dashCooldown;
        }

        public void OnThrow()
        {

        }

        public void OnSpin()
        {
            if (isSpinning || spinTimer > -spinCooldown) return;

            spinTimer = spinDuration;
            player.doFacing = false;
            isSpinning = true;
        }
    }
}
