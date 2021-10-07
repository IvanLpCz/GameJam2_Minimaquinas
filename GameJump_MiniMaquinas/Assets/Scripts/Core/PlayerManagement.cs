using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class PlayerManagement : MonoBehaviour
    {
        public GameObject playerBig, playerMin;


        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                SwaptCharacterToMini();
            }
        }
        private void SwaptCharacterToMini()
        {
            //playerMin.SetActive(true);
            //playerMin.transform.position = playerBig.transform.position;
            //playerMin.transform.rotation = playerBig.transform.rotation;
            //playerBig.SetActive(false);
            if (playerBig.activeSelf)
            {
                playerBig.SetActive(false);
                playerMin.transform.position = playerBig.transform.position;
                playerMin.transform.rotation = playerBig.transform.rotation;
                playerMin.SetActive(true);
            }
            else if (playerMin.activeSelf)
            {
                playerMin.SetActive(false);
                playerBig.transform.position = playerMin.transform.position;
                playerBig.transform.rotation = playerMin.transform.rotation;               
                playerBig.SetActive(true);
            }

        }
    }
}
