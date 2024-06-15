using UnityEngine;
using UnityEngine.Events;

namespace RobbieWagnerGames.CrappyBird
{
    public class MenuButton : MonoBehaviour
    {
        [HideInInspector] public UnityAction unityAction;

        private void Awake()
        {
            unityAction += InvokeMenuButton;
        }

        public virtual void InvokeMenuButton()
        {
            AudioManager.Instance?.PlayAudioOneShot("select");
        }
    }
}