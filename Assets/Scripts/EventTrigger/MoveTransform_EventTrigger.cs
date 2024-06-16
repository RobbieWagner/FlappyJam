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
        [SerializeField] private Vector2 resetPos = Vector2.zero;
        private Tweener tween;

        private void Awake()
        {
            startPos = objectToMove.position;
            GameManager.Instance.OnSetGameState += ResetPosition;
        }

        protected override IEnumerator InvokeEvent()
        {
            tween = objectToMove.DOMove((Vector2)objectToMove.transform.position + offset, moveTime).SetEase(Ease.Linear);
            yield return tween.WaitForKill();
        }

        private void ResetPosition(GameState state) 
        {
            if(tween != null)
            {
                tween.Kill();
                tween = null;
            }
            if (state == GameState.Playing)
            {
                if(resetPos.Equals(Vector2.zero))
                    objectToMove.position = startPos;
                else
                    objectToMove.localPosition = resetPos;
            }
        }
    }
}