using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace RobbieWagnerGames.CrappyBird
{
    public class QuitApplication : MenuButton
    {
        public override void InvokeMenuButton()
        {
            base.InvokeMenuButton();
            Application.Quit();
        }
    }
}