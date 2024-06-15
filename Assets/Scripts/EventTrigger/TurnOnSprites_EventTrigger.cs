using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RobbieWagnerGames.CrappyBird
{
    public class TurnOnSprites : EventTrigger
    {
        [SerializeField] private List<SpriteRenderer> sprites;
        [SerializeField] private bool startOn;

        private void Awake()
        {
            GameManager.Instance.OnSetGameState += Reset;

            ToggleSprites(startOn);
        }

        protected override IEnumerator InvokeEvent()
        {
            yield return null;
            if(sprites.Any())
                ToggleSprites(!sprites.First().enabled);
        }

        private void Reset(GameState state) 
        {
            if (state == GameState.Playing)
            {
                ToggleSprites(startOn);
            }
        }

        private void ToggleSprites(bool on)
        {
            foreach (var sprite in sprites) 
                sprite.enabled = on;
        }
    }
}