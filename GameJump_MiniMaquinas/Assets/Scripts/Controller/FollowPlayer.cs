using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Controller
{
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField] Transform spot;

        private void Update()
        {
            GetComponent<NavMeshAgent>().destination = spot.position;
        }

    }
}
