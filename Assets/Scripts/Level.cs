using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RobbieWagnerGames.CrappyBird
{
    public class Level : MonoBehaviour
    {
        public int levelValue = 0;
        [SerializeField] private List<GameObject> levelGameObjects;
        [SerializeField] private Collider2D enableTrigger;

        private void Awake()
        {
            GameManager.Instance.OnSetGameState += OnUpdateGameState;
        }

        private void OnUpdateGameState(GameState gameState)
        {
            switch (gameState) 
            {
                case GameState.Playing:
                    OnStartGame(); 
                    break;
                default:
                    break;
            }
        }

        private void OnStartGame()
        {
            if (levelValue < 4 && !LevelManager.Instance.activeLevels.Where(l => l.levelValue == levelValue).Any())
                EnableLevel();
            else if(levelValue >= 4)
                DisableLevel();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!LevelManager.Instance.activeLevels.Where(l => l.levelValue == levelValue).Any())
            {
                EnableLevel();

                List<Level> previousLevels = LevelManager.Instance.activeLevels.Where(l => l.levelValue < levelValue - 2).ToList();
                if (previousLevels.Any())
                {
                    foreach (Level l in previousLevels)
                        l.DisableLevel();
                }
            }
        }

        public void EnableLevel()
        {
            LevelManager.Instance.activeLevels.Add(this);
            levelGameObjects.ForEach(l => l.SetActive(true));
            enableTrigger.enabled = false;

            //Debug.Log($"Level {levelValue} enabled");
        }

        public void DisableLevel()
        {
            LevelManager.Instance.activeLevels.Remove(this);
            levelGameObjects.ForEach(l => l.SetActive(false));
            enableTrigger.enabled = true;

            //Debug.Log($"Level {levelValue} disabled");
        }
    }
}