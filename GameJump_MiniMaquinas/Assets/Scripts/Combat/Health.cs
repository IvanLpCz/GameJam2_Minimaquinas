using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combatt
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float hp = 10f;

        bool isDead = false;

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
        }
    }
}
