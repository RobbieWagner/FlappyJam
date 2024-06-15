using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobbieWagnerGames.CrappyBird
{
    public class LevelManager : MonoBehaviour
    {
        public List<Level> activeLevels = new List<Level>();

        public static LevelManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;
        }
    }
}