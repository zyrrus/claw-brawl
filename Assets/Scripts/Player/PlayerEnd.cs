using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClawBrawl
{
    public class PlayerEnd : MonoBehaviour
    {
        private Rigidbody rb;
        private AbilityController ac;
        [SerializeField] private float killHeight;
        [SerializeField] private float explodeStrength;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            ac = GetComponent<AbilityController>();
        }

        private void Update()
        {
            if (transform.position.y < killHeight)
                GameOver();
        }

        private void GameOver()
        {
            transform.position = new Vector3(0, 10, 0);
        }

        public void Explode(Vector3 origin)
        {
            if (!ac.doneThrowing) return;

            Vector3 explodeDir = (transform.position - origin).normalized;
            explodeDir.y = 1;
            rb.AddForce(explodeDir.normalized * explodeStrength, ForceMode.Impulse);
        }
    }
}
