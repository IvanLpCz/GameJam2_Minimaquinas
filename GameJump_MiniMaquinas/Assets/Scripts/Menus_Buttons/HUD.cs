using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Core;

namespace Buttons
{
    public class HUD : MonoBehaviour
    {
        Health health;

        public Button pause;
        public TextMeshProUGUI hpText;
        private float hpNumber;
        public GameObject pauseMenu;
        public GameObject playerHud;
        
        void Update()
        {
            health = GameObject.FindWithTag("Player").GetComponent<Health>();

            hpNumber = health.hp;

            hpText.text = "" + hpNumber;
            Debug.Log("numero de vida " + hpNumber);
        }
        public void PauseMenuButton()
        {
            Time.timeScale = 0;
            playerHud.SetActive(false);
            pauseMenu.SetActive(true);
        }
    }
}
