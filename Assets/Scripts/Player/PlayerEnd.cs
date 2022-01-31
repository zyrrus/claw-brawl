using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TMPro;

namespace ClawBrawl
{
    public class PlayerEnd : MonoBehaviour
    {
        private Rigidbody rb;
        private AbilityController ac;
        private static int sessionHighestScore = 0;
        private int currentScore;
        [SerializeField] private TextMeshProUGUI scoreUI;
        [SerializeField] private float killHeight;
        [SerializeField] private float explodeStrength;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            ac = GetComponent<AbilityController>();
            currentScore = 0;
        }

        private void Update()
        {
            if (transform.position.y < killHeight)
                GameOver();
        }

        private void GameOver()
        {
            // Change Scene to game over
            // Reset goes back to main
            if (sessionHighestScore < currentScore)
            {
                Debug.Log($"New high score: {currentScore}; Old HS: {sessionHighestScore}");
                sessionHighestScore = currentScore;
                currentScore = 0;
            }
            transform.position = new Vector3(0, 10, 0);
        }

        public void IncrementScore()
        {
            currentScore++;
            scoreUI.
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
