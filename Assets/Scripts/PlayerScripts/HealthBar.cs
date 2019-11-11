using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCompany.BFE
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField]
        private int health;

        public void Takedamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Destroy(gameObject);
                //Destroy(transform.parent.gameObject);
            }
        }

    }
}
