using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combatt
{
    public class Combat : MonoBehaviour, IAction
    {
        [SerializeField] float attackRange = 2f;
        [SerializeField] float timeBetweenAttaks = 1f;
        [SerializeField] float attakPower = 5f;

        Health target;
        float timeSinceLastAttack = 0;
        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;

            if (target.IsDead()) return;

            if (!GetIsInRange())
            {
                GetComponent<Movement>().MoveTo(target.transform.position);
            }
            else
            {
                GetComponent<Movement>().Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            transform.LookAt(target.transform);
            if(timeSinceLastAttack > timeBetweenAttaks)
            {
                TriggerAtk();
                timeSinceLastAttack = 0;
                target.takeDMG(attakPower);
            }
        }

        private void TriggerAtk()
        {
            GetComponent<Animator>().ResetTrigger("stopattack");
            GetComponent<Animator>().SetTrigger("attack");
        }

        void hit()
        {
            if(target == null)
            {
                return;
            }
            target.takeDMG(attakPower);
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.transform.position) < attackRange;
        }

        public bool CanAttakck(CombatTarget combatTarget)
        {
            if(combatTarget == null)
            {
                return false;
            }
            Health targetToTest = combatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead();
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<Scheduler>().StartAction(this);
            target = combatTarget.GetComponent<Health>();
            Debug.Log("El jugador esta atacando al enemigo");
        }
        public void Cancel()
        {
            StopAttack();
            target = null;
        }

        private void StopAttack()
        {
            GetComponent<Animator>().ResetTrigger("attack");
            GetComponent<Animator>().SetTrigger("stopAttack");
        }
    }
}
