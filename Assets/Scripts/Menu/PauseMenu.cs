using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace RobbieWagnerGames.CrappyBird
{
    public class PauseMenu : Menu
    {
        private PlayerControls playerControls;
        [SerializeField] private Canvas canvas;
        private bool paused = false;

        public static PauseMenu Instance { get; private set; }

        protected override void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;

            base.Awake();

            playerControls = new PlayerControls();
            playerControls.Enable();

            playerControls.Player.Pause.performed += TogglePause;
        }

        public void TogglePause(CallbackContext context)
        {
            TogglePause();
        }

        public void TogglePause()
        {
            paused = !paused;

            if (paused)
            {
                OnPause?.Invoke();
                Time.timeScale = 0f;
                canvas.enabled = true;
            }
            else
            {
                StartCoroutine(Unpause());
            }
        }
        public delegate void PauseHandler();
        public event PauseHandler OnPause;
        public event PauseHandler OnResume;

        private IEnumerator Unpause()
        {
            yield return null;
            Time.timeScale = 1f;
            canvas.enabled = false;
            yield return null;
            OnResume?.Invoke();
        }
    }
}