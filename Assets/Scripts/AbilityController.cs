using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClawBrawl
{
    public class AbilityController : MonoBehaviour
    {
        private Rigidbody rb;

        [SerializeField] private float dashStrength;
        [SerializeField] private float dashCooldown;
        private float dashTimer;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            dashTimer -= Time.deltaTime;
        }

        public void OnDash()
        {
            if (dashTimer > 0) return;

            rb.AddForce(transform.forward * dashStrength, ForceMode.Impulse);
            dashTimer = dashCooldown;
        }

        public void OnThrow()
        {

        }

        public void OnSpin()
        {

        }
    }
}
