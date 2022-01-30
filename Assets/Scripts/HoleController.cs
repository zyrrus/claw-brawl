using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClawBrawl
{
    public class HoleController : MonoBehaviour
    {
        private static float radius;
        private bool isActive = true;

        private CapsuleCollider moleCollider;

        [SerializeField] private GameObject mole;
        [SerializeField] private GameObject hole;

        private MeshRenderer holeMesh;
        [SerializeField] private Material holeMat;
        [SerializeField] private Material decoyMat;

        [Range(0, 1), SerializeField] private float chanceDecoy;
        private bool isDecoy = false;

        private void Awake()
        {
            moleCollider = GetComponent<CapsuleCollider>();
            holeMesh = hole.GetComponent<MeshRenderer>();
        }

        private void Start()
        {
            radius = Vector3.Distance(GameObject.FindGameObjectWithTag("Radius").transform.position, Vector3.zero);
            Respawn();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (isDecoy)
                Explode(other.gameObject.transform.parent.gameObject);
            Respawn();
        }

        // Utilities

        private Vector3 GenRandomVector()
        {
            float r = Random.Range(1, radius);
            float theta = Random.Range(0, 360);
            return new Vector3(r * Mathf.Cos(theta), 0, r * Mathf.Sin(theta));
        }

        private void RollDecoyChance()
        {
            float rand = Random.Range(0, 101);
            isDecoy = rand < (chanceDecoy * 100);
        }

        private void ChangeAppearance()
        {
            holeMesh.material = (isDecoy) ? decoyMat : holeMat;
        }

        // GameObject controllers

        public void Respawn()
        {
            RollDecoyChance();
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

        private void Explode(GameObject player)
        {
            player.GetComponent<PlayerEnd>().Explode(transform.position);
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
            ChangeAppearance();
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
