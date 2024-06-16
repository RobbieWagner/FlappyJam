using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RobbieWagnerGames.CrappyBird
{
    public class EnableComponent_EventTrigger : EventTrigger
    {
        [SerializeField] private List<Collider2D> colliders;
        private Dictionary<Collider2D, bool> enableCheck;

        private void Awake()
        {
            GameManager.Instance.OnStartPlaying += ResetEnabledState;

            enableCheck = new Dictionary<Collider2D, bool>();
            if (colliders != null && colliders.Any())
            {
                foreach (var collider in colliders)
                {
                    enableCheck.Add(collider, collider.enabled);
                }
            }
        }

        private void ResetEnabledState()
        {
            if(enableCheck != null && enableCheck.Any())
            {
                foreach (var check in enableCheck)
                {
                    check.Key.enabled = check.Value;
                }
            }
        }

        protected override IEnumerator InvokeEvent()
        {
            yield return null;
            if (colliders != null && colliders.Any())
            {
                foreach (Collider2D Collider2D in colliders)
                {
                    Collider2D.enabled = !Collider2D.enabled;
                }
            }
        }
    }
}