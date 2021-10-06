using Combatt;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   

namespace Core
{
    public class Movement : MonoBehaviour
    {
        private NavMeshAgent navMeshAgent;

        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<Combat>().Cancel();
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }
        public void Stop()
        {
            navMeshAgent.isStopped = true;
        }
    }
}
