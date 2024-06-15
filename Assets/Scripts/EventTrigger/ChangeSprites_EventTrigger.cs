using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace RobbieWagnerGames.CrappyBird
{
    public class ChangeSprites : EventTrigger
    {
        [SerializeField] private List<ImageExchanger> imageExchangers;   

        private void Awake()
        {
            GameManager.Instance.OnSetGameState += Reset;

            foreach(ImageExchanger e in imageExchangers)
                e.Reset();
        }

        protected override IEnumerator InvokeEvent()
        {
            yield return null;
            foreach (ImageExchanger e in imageExchangers)
                e.SetToNewSprite();
        }

        private void Reset(GameState state) 
        {
            if (state == GameState.Playing)
            {
                foreach (ImageExchanger e in imageExchangers)
                    e.Reset();
            }
        }
    }

    [Serializable]
    public class ImageExchanger
    {
        public Image image;
        public SpriteRenderer spriteRenderer;
        public Sprite initialSprite;
        public Sprite newSprite;

        public void Reset()
        {
            if(image != null)
                image.sprite = initialSprite;
            if(spriteRenderer != null)
                spriteRenderer.sprite = initialSprite;
        }

        public void SetToNewSprite()
        {
            if (image != null)
                image.sprite = newSprite;
            if (spriteRenderer != null)
                spriteRenderer.sprite = newSprite;
        }
    }
}