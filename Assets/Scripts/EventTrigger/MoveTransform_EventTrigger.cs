using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobbieWagnerGames.CrappyBird
{
    public class MoveTransform : EventTrigger
    {
        [SerializeField] private Transform objectToMove;
        [SerializeField] private Vector2 offset = Vector2.zero;
        [SerializeField] private float moveTime = 1f;
        private Vector2 startPos;

        private void Awake()
        {
            startPos = objectToMove.position;
            GameManager.Instance.OnSetGameState += ResetPosition;
        }

        protected override IEnumerator InvokeEvent()
        {
            yield return objectToMove.DOMove((Vector2) objectToMove.transform.position + offset, moveTime).SetEase(Ease.Linear).WaitForCompletion();
        }

        private void ResetPosition(GameState state) 
        {
            if (state == GameState.Playing)
            {
                objectToMove.position = startPos;
            }
        }
    }
}