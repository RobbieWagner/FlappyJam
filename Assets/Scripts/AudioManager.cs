using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;
using RobbieWagnerGames.CrappyBird;
using UnityEngine.EventSystems;

namespace RobbieWagnerGames.CrappyBird
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] [SerializedDictionary("Name", "Audio Source")] private SerializedDictionary<string, AudioSource> sounds;

        public static AudioManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;
        }

        public void PlayAudioOneShot(string audioName)
        {
            if(sounds.TryGetValue(audioName.ToLower(), out var sound))
            {
                sound.Play();
            }
        }
    }
}