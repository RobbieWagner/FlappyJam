using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RobbieWagnerGames.CrappyBird
{
    public class Menu : MonoBehaviour
    {
        [SerializeField]
        [SerializedDictionary("Button", "MenuButtons")]
        private SerializedDictionary<Button, List<MenuButton>> buttons;

        protected virtual void Awake()
        {
            foreach (Button button in buttons.Keys) 
            {
                foreach(MenuButton menuButton in buttons[button])
                {
                    button.onClick.AddListener(menuButton.unityAction);
                }
            }
        }
    }
}

