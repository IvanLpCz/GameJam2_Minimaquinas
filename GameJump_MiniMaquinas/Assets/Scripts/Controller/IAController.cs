using Combatt;
using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class IAController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 10f;
        [SerializeField] PatrolPath patrolPath;
        [SerializeField] float wayPointTolerance = 1f;
        private GameObject player;
        private Combat combat;
        private Health health;
        private Movement movement;

        private Vector3 guardingLocation;
        private int currentWayPointIndex = 0;
        

        private void Start()
        {            
            combat = GetComponent<Combat>();
            health = GetComponent<Health>();
            movement = GetComponent<Movement>();

            guardingLocation = transform.position;
        }
        private void FixedUpdate()
        {
            player = GameObject.FindWithTag("Player");
        }
        private void Update()
        {
            if (health.IsDead()) return;

            if(InRange() && combat.CanAttakck(player))
            {
                combat.Attack(player);
                Debug.Log("Debe de Perseguir al jugador");
            }
            else
            {
                PatrolBehaviour();
            }
        }

        private void PatrolBehaviour()
        {
            Vector3 nextPosition = guardingLocation;

            if(patrolPath != null)
            {
                if (Atwaypoint())
                {
                    CycleWaypoint();
                }
                nextPosition = GetCurrentWayPoint();
            }

            movement.StartMoveAction(nextPosition);
        }

        private Vector3 GetCurrentWayPoint()
        {
            return patrolPath.GetWayPoint(currentWayPointIndex);
        }

        private void CycleWaypoint()
        {
            currentWayPointIndex = patrolPath.GetNextIndex(currentWayPointIndex);
        }

        private bool Atwaypoint()
        {
            float distanceToWayPoint = Vector3.Distance(transform.position, GetCurrentWayPoint());
            return distanceToWayPoint < wayPointTolerance;
        }

        private bool InRange()
        {
            float DistanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return DistanceToPlayer < chaseDistance;
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}
