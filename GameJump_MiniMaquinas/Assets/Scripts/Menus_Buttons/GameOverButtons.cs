using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Buttons
{
    public class GameOverButtons : MonoBehaviour
    {
        public Button tryAgain, exit;
        private Scene activeScene;

        private void Start()
        {
            activeScene = SceneManager.GetActiveScene();
        }
        public void TryAgain()
        {
            SceneManager.LoadScene(activeScene.name);
        }
        public void ToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

}

