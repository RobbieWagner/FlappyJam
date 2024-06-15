using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RobbieWagnerGames.CrappyBird
{
    public class ResumeGame : MenuButton
    {
        public override void InvokeMenuButton()
        {
            PauseMenu.Instance.TogglePause();
        }
    }
}