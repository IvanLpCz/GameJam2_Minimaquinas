using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Controller
{
    public class PlayerControllerMini : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                MoveToCursor();
            }
        }

        private void MoveToCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool hashit = Physics.Raycast(ray, out hit);
            if(hashit)
            {
                GetComponent<NavMeshAgent>().destination = hit.point;
            }
        }
    }
}
