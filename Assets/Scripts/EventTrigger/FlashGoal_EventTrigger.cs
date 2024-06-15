using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace RobbieWagnerGames.CrappyBird
{
    public class FlashGoal : EventTrigger
    { 
        protected override IEnumerator InvokeEvent()
        {
            GoalFlash.Instance.FlashGoal();
            yield return null;
        }
    }
}