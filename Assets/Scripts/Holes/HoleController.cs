using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClawBrawl
{
    public class HoleController : MonoBehaviour
    {
        private static float radius;
        [SerializeField] private GameObject player;
        private PlayerEnd playerEnd;

        private CapsuleCollider moleCollider;
        [SerializeField] private GameObject mole;
        [SerializeField] private GameObject hole;
        private Renderer holeMesh;
        [SerializeField] private Material holeMat;
        [SerializeField] private Material decoyMat;
        private bool isDecoy = false;

        private static float chanceDecoy;


        private void Awake()
        {
            moleCollider = GetComponent<CapsuleCollider>();
            holeMesh = hole.GetComponent<Renderer>();
        }

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerEnd = player.GetComponent<PlayerEnd>();

            chanceDecoy = transform.parent.gameObject.GetComponent<InitHoles>().chanceDecoy;

            radius = Vector3.Distance(GameObject.FindGameObjectWithTag("Radius").transform.position, Vector3.zero);
            Respawn();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (isDecoy)
                Explode();
            Respawn();
            ScoreContainer.Instance.IncrementScore();
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

        private void ChangeDecoyAppearance()
        {
            holeMesh.material.color = (isDecoy) ? decoyMat.color : holeMat.color;
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

        private void Explode()
        {
            playerEnd.Explode(transform.position);
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
            ChangeDecoyAppearance();
            DisableMole();
        }

        private void EnableMole()
        {
            moleCollider.enabled = true;
            mole.SetActive(true);
        }

        private void DisableMole()
        {
            moleCollider.enabled = false;
            mole.SetActive(false);
        }
    }
}
