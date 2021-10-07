using Core;
using Combatt;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        Health health;
        public bool canAttack;

        private void Start()
        {
            health = GetComponent<Health>();
        }
        private void Update()
        {
            if (health.IsDead()) return;
            if (canAttack)
            {
                if (InteractCombat()) return;
            }            
            if(InteractMovement()) return;
        }


        private bool InteractCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) continue;

                GameObject targetGameObject = target.gameObject;
                if (!GetComponent<Combat>().CanAttakck(target.gameObject))
                {
                    continue;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Combat>().Attack(target.gameObject);
                }
                return true;
            }
            return false;
        }
        private bool InteractMovement()
        {
            Ray ray = GetRay();
            RaycastHit hit;
            bool hashit = Physics.Raycast(ray, out hit);

            if (hashit)
            {               
                {
                    if (Input.GetMouseButton(0))
                    {
                        GetComponent<Movement>().StartMoveAction(hit.point);
                    }                   
                }
                return true;
            }
            return false;
        }

        private static Ray GetRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}