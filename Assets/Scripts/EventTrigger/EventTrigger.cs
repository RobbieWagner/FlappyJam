using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobbieWagnerGames.CrappyBird
{
    public class EventTrigger : MonoBehaviour
    {
        protected void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
                StartCoroutine(InvokeEvent());
        }

        protected virtual IEnumerator InvokeEvent()
        {
            yield return null;
        }
    }
}