using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace RobbieWagnerGames.CrappyBird
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb2d;
        [SerializeField] private Collider2D col;
        [SerializeField] private float flapForce = 5f;
        [SerializeField] private float flapCooldown = .5f;
        [SerializeField] private Animator animator;

        private PlayerControls playerControls;

        private bool canFlap = false;

        public static PlayerController Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;

            playerControls = new PlayerControls();
            playerControls.Player.Flap.performed += Flap;
            ResetPlayer();

            GameManager.Instance.OnSetGameState += CheckGameState;
            PauseMenu.Instance.OnPause += DisableControls;
            PauseMenu.Instance.OnResume += EnableControls;
        }

        private void CheckGameState(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Playing:
                    ResetPlayer(); 
                    break;
                case GameState.GameOver:
                    SetToGameOverFall(); 
                    break;
                case GameState.Win:
                    DisableControls();
                    break;
                default:
                    break;
            }
        }

        public void ResetPlayer()
        {
            rb2d.angularVelocity = 0;
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            transform.rotation = Quaternion.identity;
            canFlap = true;
            col.enabled = true;
            playerControls.Enable();
        }

        public void SetToGameOverFall()
        {
            playerControls.Disable();
            col.enabled = false;
        }

        private void Flap(CallbackContext context)
        {
            if (canFlap)
            {
                Flap();
                canFlap = false;
                StartCoroutine(CooldownFlap());
                AudioManager.Instance.PlayAudioOneShot("flap");
                animator.SetTrigger("Flap");
            }
        }

        private void Flap()
        {
            rb2d.velocity = Vector2.right * ObjectPanController.Instance.GetPanControllerSpeed();
            rb2d.AddForce(Vector2.up * flapForce, ForceMode2D.Impulse);
        }

        private IEnumerator CooldownFlap()
        {
            yield return new WaitForSeconds(flapCooldown);
            canFlap = true;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Hazard") && GameManager.Instance.CurrentGameState == GameState.Playing)
                GameManager.Instance.GameOver();
        }

        private void EnableControls()
        {
            playerControls.Enable();
        }

        private void DisableControls()
        {
            playerControls.Disable();
        }
    }
}
