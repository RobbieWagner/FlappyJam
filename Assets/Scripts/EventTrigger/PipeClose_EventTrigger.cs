using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobbieWagnerGames.CrappyBird
{
    public class PipeClose : EventTrigger
    {
        [SerializeField] private Transform topPipe;
        [SerializeField] private Transform bottomPipe;
        [SerializeField] private float centerY;
        [SerializeField] private float gapSize = 10f;
        [SerializeField] private float closeTime = .2f;

        Vector2 topPipeInitialPos;
        Vector2 bottomPipeInitialPos;

        private void Awake()
        {
            topPipeInitialPos = topPipe.position;
            bottomPipeInitialPos = bottomPipe.position;
            GameManager.Instance.OnSetGameState += ResetTransforms;
        }

        private void ResetTransforms(GameState state)
        {
            if(state == GameState.Playing)
            {
                topPipe.position = topPipeInitialPos;
                bottomPipe.position = bottomPipeInitialPos;
            }
        }

        protected override IEnumerator InvokeEvent()
        {
            Vector2 center = new Vector2 (topPipe.transform.position.x, centerY);

            topPipe.DOMove(center + (Vector2.up * gapSize/2), closeTime).SetEase(Ease.Linear);
            yield return bottomPipe.DOMove(center - (Vector2.up * gapSize/2), closeTime).SetEase(Ease.Linear).WaitForCompletion();
        }
    }
}