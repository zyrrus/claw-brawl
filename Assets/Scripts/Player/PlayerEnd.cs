using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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
            ScoreContainer.Instance.HandleGameOver();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
