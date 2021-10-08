using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class PlayerManagement : MonoBehaviour
    {
        public GameObject playerBig, playerMin, cameraBig, cameraMin;


        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                SwaptCharacterToMini();
            }
        }
        private void SwaptCharacterToMini()
        {
            if (playerBig.activeSelf)
            {
                playerBig.SetActive(false);
                playerMin.transform.position = playerBig.transform.position;
                playerMin.transform.rotation = playerBig.transform.rotation;
                playerMin.SetActive(true);
                cameraBig.SetActive(false);
                cameraMin.SetActive(true);
            }
            else if (playerMin.activeSelf)
            {
                playerMin.SetActive(false);
                playerBig.transform.position = playerMin.transform.position;
                playerBig.transform.rotation = playerMin.transform.rotation;               
                playerBig.SetActive(true);
                cameraMin.SetActive(false);
                cameraBig.SetActive(true);
            }

        }
    }
}
