using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace RobbieWagnerGames.CrappyBird
{
    public class PlayGame : MenuButton
    {
        [SerializeField] private string sceneName;
        public override void InvokeMenuButton()
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}