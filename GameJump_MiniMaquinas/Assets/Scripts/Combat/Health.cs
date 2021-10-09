using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] public float hp = 10f;

        bool isDead = false;
        public GameObject deathMenu;

        public bool IsDead()
        {
            return isDead;
        }

        public void takeDMG(float damage)
        {
            hp = Mathf.Max(hp - damage, 0);
            print(hp);
            if(hp == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (isDead) return;

            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<Scheduler>().CancelCurrentAction();
            if (CompareTag("Player"))
            {
                deathMenu.SetActive(true);
            }
        }
    }
}
