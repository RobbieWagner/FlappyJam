using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobbieWagnerGames.CrappyBird
{
    public class ToggleObjects : EventTrigger
    {
        [SerializeField] private List<GameObject> toggleObjects;
        private List<TrackedToggleObject> TrackedToggleObjects;
        [SerializeField] private bool toggleOn;

        private void Awake()
        {
            GameManager.Instance.OnStartPlaying += ResetObjectEnableState;
            TrackedToggleObjects = new List<TrackedToggleObject>();
            foreach (GameObject go in toggleObjects)
            {
                TrackedToggleObjects.Add(new TrackedToggleObject { gameObject = go, isOn = go.activeSelf });
            }
        }

        private void ResetObjectEnableState()
        {
            foreach(TrackedToggleObject t in TrackedToggleObjects)
                t.gameObject.SetActive(t.isOn);
        }

        protected override IEnumerator InvokeEvent()
        {
            yield return null;
            foreach (GameObject go in toggleObjects) 
            {
                go.SetActive(toggleOn);
            }
        }
    }
}