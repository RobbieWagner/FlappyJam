using DG.Tweening;
using RobbieWagnerGames.CrappyBird;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RobbieWagnerGames.CrappyBird
{
    public class GoalFlash : MonoBehaviour
    {
        [SerializeField] private Image goal;
        [SerializeField] private Vector2 visiblePos;
        [SerializeField] private Vector2 initialPos;

        public static GoalFlash Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;

            GameManager.Instance.OnStartPlaying += FlashGoal;
        }

        public void FlashGoal()
        {
            StartCoroutine(FlashGoalCo());
        }

        private IEnumerator FlashGoalCo()
        {
            yield return goal.rectTransform.DOAnchorPos(visiblePos, .5f).SetEase(Ease.Linear).WaitForCompletion();
            yield return new WaitForSeconds(2);
            yield return goal.rectTransform.DOAnchorPos(initialPos, .5f).SetEase(Ease.Linear).WaitForCompletion();
        }
    }
}