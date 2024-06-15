using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace RobbieWagnerGames.CrappyBird
{
    public class ScoreTracker : MonoBehaviour
    {
        private int score = 0;
        public int Score
        {
            get { return score; }
            set 
            {
                if (score == value) 
                    return;
                if (value > score)
                    AudioManager.Instance.PlayAudioOneShot("point");
                score = value; 
                OnScoreUpdated?.Invoke(score);
            }
        }
        public delegate void ScoreHandler(int score);
        public event ScoreHandler OnScoreUpdated;

        [SerializeField] private TextMeshProUGUI scoreText;

        public static ScoreTracker Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;

            OnScoreUpdated += UpdateScoreText;
            GameManager.Instance.OnSetGameState += CheckTrackerReset;
        }

        private void CheckTrackerReset(GameState state)
        {
            if(state == GameState.Playing)
            {
                score = 0;
                scoreText.text = $"{score}";
            }
        }

        private void UpdateScoreText(int scoreValue)
        {
            scoreText.text = $"{scoreValue}";
        }


    }
}