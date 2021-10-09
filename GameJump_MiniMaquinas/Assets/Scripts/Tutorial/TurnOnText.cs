using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tuto
{
    public class TurnOnText : MonoBehaviour
    {
        public GameObject tutoText;

        private void OnTriggerEnter(Collider other)
        {
            tutoText.SetActive(true);
        }
    }

}