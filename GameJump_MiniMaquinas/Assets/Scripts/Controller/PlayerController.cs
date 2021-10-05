using Core;
using Combatt;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        private void Update()
        {
            if(InteractCombat()) return;
            if(InteractMovement()) return;
        }


        private bool InteractCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) continue;

                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Combat>().Attack();
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
                GetComponent<Combat>().Attack();
                {
                    GetComponent<Movement>().MoveTo(hit.point);
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