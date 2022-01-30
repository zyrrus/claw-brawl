using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClawBrawl
{
    class Anchor
    {
        public Vector3 forward;
        public Vector3 position;
        public Quaternion rotation;

        public Anchor(Transform anchor)
        {
            this.forward = anchor.forward;
            this.position = anchor.position;
            this.rotation = anchor.rotation;
        }
    }

    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private float throwDuration;
        [SerializeField] private float throwSpeed;
        [SerializeField] private float throwSpinSpeed;
        [SerializeField] private bool isThrowing = false;
        [SerializeField] private bool isLeaving = true;
        private Anchor targetPeak;
        private Vector3 originalOffset;
        private Transform parentTransform;

        private void Start()
        {
            originalOffset = transform.localPosition;
        }

        private void Update()
        {
            parentTransform = transform.parent.transform;

            if (isThrowing)
            {
                // Normalize Rotation
                transform.rotation = targetPeak.rotation;
                transform.Rotate(Vector3.up * throwSpinSpeed * Time.deltaTime);
                targetPeak.rotation = transform.rotation;

                // Handle weapon leave and return
                if (isLeaving)
                    targetPeak.position += targetPeak.forward * throwSpeed * Time.deltaTime;
                else
                {
                    targetPeak.position += (parentTransform.position - targetPeak.position).normalized * throwSpeed * Time.deltaTime;
                    if (Vector3.Distance(targetPeak.position, parentTransform.position) < 0.5f)
                        isThrowing = false;
                }

                transform.position = targetPeak.position;
            }

            // Reset to default when not throwing
            if (!isThrowing)
            {
                transform.rotation = parentTransform.rotation;
                transform.localPosition = originalOffset;
            }
        }

        public bool CanThrow()
        {
            return !isThrowing;
        }

        public void Throw()
        {
            targetPeak = new Anchor(transform.parent.transform);
            isThrowing = true;
            isLeaving = true;

            StartCoroutine(PeakOfThrow());
        }

        private IEnumerator PeakOfThrow()
        {
            yield return new WaitForSeconds(throwDuration);
            isLeaving = false;

        }
    }
}
