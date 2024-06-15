using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobbieWagnerGames.CrappyBird
{
    public partial class Pipes : MonoBehaviour
    {
        private bool passed = false;

        protected virtual void Awake()
        {
            GameManager.Instance.OnSetGameState += CheckPassReset;
        }

        private void CheckPassReset(GameState state)
        {
            if (state == GameState.Playing)
            {
                passed = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player") && !passed)
            {
                ScoreTracker.Instance.Score += 1;
                passed = true;
            }
        }
    }
}