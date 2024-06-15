using System.Collections;
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
            base.InvokeMenuButton();
            StartCoroutine(TransitionScene());
        }

        private IEnumerator TransitionScene()
        {
            yield return new WaitForSecondsRealtime(.25f);
            SceneManager.LoadScene(sceneName);
            Time.timeScale = 1.0f;
        }
    }
}