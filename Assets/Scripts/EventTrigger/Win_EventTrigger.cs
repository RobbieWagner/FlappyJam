using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobbieWagnerGames.CrappyBird
{
    public class WinEvent : EventTrigger
    {
        protected override IEnumerator InvokeEvent()
        {
            if (GameManager.Instance.CurrentGameState == GameState.Playing)
                GameManager.Instance.Win();
            yield return null;
        }
    }
}