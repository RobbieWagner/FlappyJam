using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobbieWagnerGames.CrappyBird
{
    public class MovingPipes : Pipes
    {
        [SerializeField] private Vector2 pipesOffset;
        [SerializeField] private Transform pipeTransform;
        [SerializeField] private float moveTime = 1f;

        private Vector2 pipesInitialPosition;
        private Vector2 pipesFinalPosition;

        protected override void Awake()
        {
            base.Awake();
            pipesInitialPosition = pipeTransform.position;
            pipesFinalPosition = (Vector2)pipeTransform.position + pipesOffset;

            StartCoroutine(MovePipes());
        }

        private IEnumerator MovePipes()
        {
            while (true) 
            {
                yield return pipeTransform.DOMove(pipesFinalPosition, moveTime).SetEase(Ease.Linear).WaitForCompletion();
                yield return pipeTransform.DOMove(pipesInitialPosition, moveTime).SetEase(Ease.Linear).WaitForCompletion();
            }
        }
    }
}
