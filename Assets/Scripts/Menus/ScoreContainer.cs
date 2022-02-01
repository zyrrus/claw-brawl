using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ClawBrawl
{
    public class ScoreContainer : PersistentSingleton<ScoreContainer>
    {
        public static int highestScore = 0;
        public static int score = 0;

        [SerializeField] private TextMeshProUGUI scoreUI;

        public void IncrementScore()
        {
            score++;
            UpdateGameUI();
        }

        private void UpdateGameUI()
        {
            scoreUI.SetText("Score: {0}", score);
        }

        public void HandleGameOver()
        {
            if (score > highestScore) highestScore = score;
        }

        public void ResetScore()
        {
            score = 0;
        }
    }
}
