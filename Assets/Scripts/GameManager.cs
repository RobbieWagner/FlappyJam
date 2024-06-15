using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RobbieWagnerGames.CrappyBird
{
    public enum GameState
    {
        None = 0,
        Playing = 1,
        GameOver = 2,
        Win = 3
    }

    public class GameManager : MonoBehaviour
    {
        public float restartTime = 3f;
        [SerializeField] private Canvas canvas;
        [SerializeField] private Image winScreen;

        private GameState currentGameState = GameState.None;
        public GameState CurrentGameState
        {
            get 
            { 
                return currentGameState; 
            }
            set 
            {
                if(currentGameState == value)
                    return;
                currentGameState = value;

                OnSetGameState?.Invoke(currentGameState);
                if (currentGameState == GameState.Playing)
                    OnStartPlaying?.Invoke();
            }
        }
        public delegate void GameStateDelegate(GameState state);
        public event GameStateDelegate OnSetGameState;
        public delegate void DefaultHandler();
        public event DefaultHandler OnStartPlaying;

        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;

            canvas.enabled = false;
            StartCoroutine(LoadLevel());
        }

        public IEnumerator LoadLevel()
        {
            yield return null;
            CurrentGameState = GameState.Playing;
        }
        
        public void GameOver()
        {
            CurrentGameState = GameState.GameOver;
            AudioManager.Instance.PlayAudioOneShot("fail");
            StartCoroutine(Restart());
        }

        public IEnumerator Restart()
        {
            yield return new WaitForSeconds(restartTime);
            yield return StartCoroutine(LoadLevel());
        }

        public void Win()
        {
            CurrentGameState = GameState.Win;
            //AudioManager.Instance.PlayAudioOneShot();
            StartCoroutine(WinCo());
        }

        public IEnumerator WinCo()
        {
            CurrentGameState = GameState.Win;
            winScreen.color = new Color(1,1,1,0);
            winScreen.enabled = true;
            canvas.enabled = true;
            AudioManager.Instance.PlayAudioOneShot("win");
            yield return winScreen.DOColor(Color.white, 1f).SetEase(Ease.Linear).WaitForCompletion();

            SceneManager.LoadScene("Main Menu");
        }
    }
}