using Combatt;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class IAController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 10f;
        private GameObject player;
        Combat combat;

        private void Start()
        {
            player = GameObject.FindWithTag("Player");
            combat = GetComponent<Combat>();
        }
        private void Update()
        {           
            if(InRange() && combat.CanAttakck(player))
            {
                combat.Attack(player);
                Debug.Log("Debe de Perseguir al jugador");
            }
            else
            {
                combat.Cancel();
            }
        }

        private bool InRange()
        {
            float DistanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return DistanceToPlayer < chaseDistance;
        }
    }
}
