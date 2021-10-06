using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combatt
{
    public class Combat : MonoBehaviour
    {
        [SerializeField] float attackRange = 2f;
        Transform target;
        private void Update()
        {
            if (target == null) return;

            if (!GetIsInRange())
            {
                GetComponent<Movement>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Movement>().Stop();
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < attackRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
            Debug.Log("El jugador esta atacando al enemigo");
        }
        public void Cancel()
        {
            target = null;
        }
    }
}
