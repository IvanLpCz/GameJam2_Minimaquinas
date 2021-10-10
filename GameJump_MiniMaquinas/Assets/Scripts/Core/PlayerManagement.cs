using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class PlayerManagement : MonoBehaviour
    {
        public GameObject playerBig, playerMin, cameraBig, cameraMin, block;


        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                SwaptCharacterToMini();
            }
        }
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "ChangePlayer")
            {
                SwaptCharacterToMini();
                Debug.Log("entra en contacto");
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
                block.SetActive(false);
            }
            else if (playerMin.activeSelf)
            {
                playerMin.SetActive(false);
                playerBig.transform.position = playerMin.transform.position;
                playerBig.transform.rotation = playerMin.transform.rotation;               
                playerBig.SetActive(true);
                cameraMin.SetActive(false);
                cameraBig.SetActive(true);
                block.SetActive(true);
            }

        }
    }
}
