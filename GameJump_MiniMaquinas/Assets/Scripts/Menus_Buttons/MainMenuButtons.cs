using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Buttons
{
    public class MainMenuButtons : MonoBehaviour
    {
        public Button play, credits, exit;

        public void StartGame()
        {
            SceneManager.LoadScene("Level1");
        }
        public void CreditsScene()
        {
            SceneManager.LoadScene("CreditsMenu");
        }
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
