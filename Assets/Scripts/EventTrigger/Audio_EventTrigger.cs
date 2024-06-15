using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace RobbieWagnerGames.CrappyBird
{
    public class PlayAudioEventTrigger : EventTrigger
    {
        [SerializeField] private string audioName;  

        protected override IEnumerator InvokeEvent()
        {
            yield return null;
            AudioManager.Instance.PlayAudioOneShot(audioName);
        }
    }
}