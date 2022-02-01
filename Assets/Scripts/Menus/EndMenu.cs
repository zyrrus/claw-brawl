using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace ClawBrawl
{
    public class EndMenu : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI finalScore;
        [SerializeField] private TextMeshProUGUI highestScore;


        public static void OnClickPlayAgain()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            ScoreContainer.Instance.ResetScore();
        }

        public static void OnClickQuit()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
            ScoreContainer.Instance.ResetScore();
        }

        private void Start()
        {
            finalScore.SetText("Final Score: {0}", ScoreContainer.score);
            highestScore.SetText("High Score: {0}", ScoreContainer.highestScore);
        }
    }
}
