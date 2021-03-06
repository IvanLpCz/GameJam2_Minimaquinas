using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Buttons
{
    public class PauseButtons : MonoBehaviour
    {
        public Button contune, restart, exit;
        private Scene actualScene;
        public GameObject inGameHUD, pauseMenu;

        public void Start()
        {
            actualScene = SceneManager.GetActiveScene();
        }
        public void ContinueButton()
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            inGameHUD.SetActive(true);
        }
        public void RestartButton()
        {
            SceneManager.LoadScene(actualScene.name);
            Time.timeScale = 1;
        }
        public void ExitButton()
        {
            SceneManager.LoadScene("MainMenu");
            Time.timeScale = 1;
        }
    }
}
