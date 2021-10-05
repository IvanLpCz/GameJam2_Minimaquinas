using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Controller
{
    public class PlayerControllerMini : MonoBehaviour
    {
        public GameObject lider;
        private Vector3 offset;
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
            if (hashit)
            {
                GetComponent<NavMeshAgent>().destination = hit.point;

                //Vector3 offsetN = ray.GetPoint(hit);
                //offset = lider.transform.position - offsetN;
            }
        }
    }
}
