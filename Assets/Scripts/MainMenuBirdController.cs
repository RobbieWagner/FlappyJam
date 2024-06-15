using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RobbieWagnerGames.CrappyBird
{
    public class MainMenuBirdController : MonoBehaviour
    {
        [SerializeField] private List<NPCBird> birdPrefabs;
        [SerializeField] private Vector2 yPosMinAndMax;
        [SerializeField] private Vector2 timeBetweenBirds;
        [SerializeField] private float maxBirdsAtOnce = 3;

        private void Awake()
        {
            StartCoroutine(RunBirdSpawns());
            AudioManager.Instance?.PlayAudioOneShot("opening");
        }

        private IEnumerator RunBirdSpawns()
        {
            while (true) 
            {
                float birdCount = Random.Range(1, maxBirdsAtOnce);
                for (int i = 0; i < birdCount; i++) 
                {
                    NPCBird bird = Instantiate(birdPrefabs[i]);
                    bird.yPos = Random.Range(yPosMinAndMax.x, yPosMinAndMax.y);
                    yield return new WaitForSeconds(Random.Range(1, 3));
                }

                yield return new WaitForSeconds(Random.Range(timeBetweenBirds.x, timeBetweenBirds.y));
            }
        }
    }
}
