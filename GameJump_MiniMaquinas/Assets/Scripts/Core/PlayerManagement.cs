using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class PlayerManagement : MonoBehaviour
    {
        public GameObject playerMax, playerMini;
        public bool miniIsActive, maxIsActive;

        private void Start()
        {
            maxIsActive = true;
            miniIsActive = false;
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                SwaptCharacterToMini();
            }
        }
        private void SwaptCharacterToMini()
        {
            Vector3 PlayerMaxPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

            if(miniIsActive == false)
            {
                playerMini.transform.position = PlayerMaxPosition;
            }            
            playerMax.SetActive(false);
            playerMini.SetActive(true);

        }
    }
}
