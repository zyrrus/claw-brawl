using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClawBrawl
{
    public class HoleManager : MonoBehaviour
    {
        private bool isActive = true;
        private CapsuleCollider moleCollider;
        [SerializeField] private BoxCollider bcParent;
        [SerializeField] private GameObject mole;
        [SerializeField] private GameObject hole;

        private void Awake()
        {
            moleCollider = GetComponent<CapsuleCollider>();
        }

        private void Start()
        {
            bcParent = transform.parent.gameObject.GetComponent<BoxCollider>();
            Respawn();
        }

        private void OnTriggerEnter(Collider other)
        {
            Respawn();
        }

        // Utilities

        private Vector3 GenRandomVector()
        {
            float x = Random.Range(bcParent.bounds.min.x, bcParent.bounds.max.x);
            float z = Random.Range(bcParent.bounds.min.z, bcParent.bounds.max.z);
            return new Vector3(x, 0, z);
        }

        // GameObject controllers

        public void Respawn()
        {
            StartCoroutine(_Respawn());
        }

        private IEnumerator _Respawn()
        {
            DisableMole();
            yield return new WaitForSeconds(Random.Range(0.2f, 1.5f));
            DeactivateHole();
            Move();
            yield return new WaitForSeconds(Random.Range(0.5f, 3));
            ActivateHole();
            yield return new WaitForSeconds(Random.Range(0.5f, 5f));
            EnableMole();
        }

        private void Move()
        {
            transform.position = GenRandomVector();
        }

        private void ActivateHole()
        {
            hole.SetActive(true);
        }

        private void DeactivateHole()
        {
            hole.SetActive(false);
            DisableMole();
        }

        private void EnableMole()
        {
            isActive = true;
            moleCollider.enabled = true;
            mole.SetActive(true);
        }

        private void DisableMole()
        {
            isActive = false;
            moleCollider.enabled = false;
            mole.SetActive(false);
        }
    }
}
