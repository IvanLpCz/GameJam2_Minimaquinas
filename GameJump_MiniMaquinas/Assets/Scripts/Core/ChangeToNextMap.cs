using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class ChangeToNextMap : MonoBehaviour
    {
        private int sceneID;
        public void Start()
        {
            sceneID = SceneManager.GetActiveScene().buildIndex;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
               sceneID++;
               SceneManager.LoadScene(sceneID);
               
            }
            Debug.Log("entra en contacto");
        }

    }
}
