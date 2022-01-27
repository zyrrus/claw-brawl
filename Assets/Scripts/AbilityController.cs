using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClawBrawl
{
    public class AbilityController : MonoBehaviour
    {
        private Rigidbody rb;
        private PlayerMovement player;

        [SerializeField] private bool canDash = true;
        [SerializeField] private float dashStrength;
        [SerializeField] private float dashCooldown;
        [SerializeField] private float dashTimer;

        [SerializeField] private bool canThrow = true;
        [SerializeField] private float throwStrength;
        [SerializeField] private float throwCooldown;
        private float throwTimer;

        [SerializeField] private bool canSpin = true;
        [SerializeField] private bool isSpinning;
        [SerializeField] private float spinSpeed;
        [SerializeField] private float spinDuration;
        [SerializeField] private float spinCooldown;
        private float spinTimer;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            player = GetComponent<PlayerMovement>();
        }

        private void Update()
        {

            if (dashTimer >= 0)
                dashTimer -= Time.deltaTime;

            if (isSpinning)
            {
                transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
            }
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
            player.doFacing = !player.doFacing;
            isSpinning = !isSpinning;
        }
    }
}
