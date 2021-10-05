using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   

namespace Core
{
    public class Movement : MonoBehaviour
    {
        public float offset;
        private void Update()
        {

            if (Input.GetMouseButtonDown(0))
            {
                MoveToDesire();
            }       
        }
        private void MoveToDesire()
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
