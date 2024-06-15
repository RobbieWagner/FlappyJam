using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace RobbieWagnerGames.CrappyBird
{
    public class NPCBird : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb2d;
        [SerializeField] private Collider2D col;
        [SerializeField] private float flapForce = 5f;
        [SerializeField] private float flapCooldown = .5f;
        [SerializeField] private Animator animator;
        [SerializeField] private float speed = 5;
        [SerializeField] private float xDeathPos = 55f;
        [HideInInspector] public float yPos = 0;

        private bool canFlap = true;

        private void Awake()
        {
            StartCoroutine(InitializeBird());
        }

        private IEnumerator InitializeBird()
        {
            yield return null;
            transform.position = new Vector2(transform.position.x, yPos);
            StartCoroutine(FlapAcrossScreen());
        }

        private IEnumerator FlapAcrossScreen()
        {
            rb2d.velocity = new Vector2(speed, 0);
            float yPos = transform.position.y;

            while (transform.position.x < xDeathPos)
            {
                yield return null;
                if(transform.position.y < yPos)
                {
                    Flap();
                    yield return StartCoroutine(CooldownFlap());
                }
            }
            Destroy(gameObject);
        }

        private void Flap()
        {
            rb2d.velocity = Vector2.right * speed;
            rb2d.AddForce(Vector2.up * flapForce, ForceMode2D.Impulse);
            animator.SetTrigger("Flap");
            AudioManager.Instance.PlayAudioOneShot("flap");
        }

        private IEnumerator CooldownFlap()
        {
            yield return new WaitForSeconds(flapCooldown);
            canFlap = true;
        }
    }
}
