using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace RobbieWagnerGames.CrappyBird
{
    public class ObjectPanController : MonoBehaviour
    {
        [SerializeField] private List<Rigidbody2D> rb2ds;
        private Dictionary<Rigidbody2D, Vector3> startingPositions = new Dictionary<Rigidbody2D, Vector3>();
        [SerializeField] private float speed = 5f;

        public static ObjectPanController Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;

            foreach(var r in rb2ds)
            {
                startingPositions.Add(r, r.transform.position);
            }

            GameManager.Instance.OnSetGameState += OnSetGameState;
        }

        private void OnSetGameState(GameState gameState)
        {
            switch (gameState) 
            {
                case GameState.Playing:
                    StartGame();
                    break;
                case GameState.GameOver:
                    EndGame();
                    break;
                default:
                    break;
            }
        }

        public void StartGame()
        {
            foreach (Rigidbody2D rb2d in rb2ds)
            {
                rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
                rb2d.transform.position = startingPositions[rb2d];
            }
        }

        public void EndGame()
        {
            foreach (Rigidbody2D rb2d in rb2ds)
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        public float GetPanControllerSpeed()
        {
            return speed;
        }
    }

}